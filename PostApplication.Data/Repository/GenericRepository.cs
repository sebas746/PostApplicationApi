using Microsoft.EntityFrameworkCore;
using PostApplication.DataContext.PostApplication;
using PostApplication.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal readonly PostApplicationContext _context;
        internal readonly DbSet<TEntity> _dbSet;
        public GenericRepository(PostApplicationContext context)
        {
            if (context == null) return;
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(inc =>
            {
                query = query.Include(inc);
            });
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        /// <see cref="IGenericRepository{TEntity}.Get(Expression{Func{TEntity,bool}},Func{IQueryable{TEntity},IOrderedQueryable{TEntity}},string)"/>
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>
            , IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public IQueryable<TEntity> GetQueryable(int skip, int take, Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (take < 1)
            {
                return orderBy != null ? orderBy(query).Skip(skip) : query.Skip(skip);
            }

            return orderBy != null ? orderBy(query).Skip(skip).Take(take) : query.Skip(skip).Take(take);
        }
        ///<see cref="IGenericRepository{TEntity}.GetByID"/>
        public virtual TEntity GetByID(object id)
        {
            return _dbSet.Find(id);
        }
        ///<see cref="IGenericRepository{TEntity}.GetByID"/>
        public virtual TEntity GetByID(object id1, object id2)
        {
            return _dbSet.Find(id1, id2);
        }

        public IList<TEntity> GetPaginated(int skip, int take, Expression<Func<TEntity, bool>> filter = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            return GetQueryable(skip, take, filter, orderBy, includes).ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(AddCreationData(entity));
        }
        public virtual void Delete(object id)
        {
            var entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(object id1, object id2)
        {
            var entityToDelete = _dbSet.Find(id1, id2);
            Delete(entityToDelete);
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(AddModificationData(entityToUpdate));
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.Count(filter ?? throw new ArgumentNullException(nameof(filter)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityToUpdate"></param>
        /// <returns></returns>
        private TEntity AddModificationData(TEntity entity)
        {
            if (entity.GetType().GetMethods().Contains(entity.GetType().GetMethod("set_Modified")))
            {
                if (entity.GetType().GetProperty("Modified").PropertyType.Name.Equals("String", StringComparison.InvariantCulture))
                {
                    object[] param = { DateTime.UtcNow.ToString(string.Empty, CultureInfo.InvariantCulture) };
                    entity.GetType().GetMethod("set_Modified").Invoke(entity, param);
                }
                else
                {
                    if (entity.GetType().GetProperty("Modified").PropertyType.Name.Equals("Datetime", StringComparison.InvariantCulture) ||
                        entity.GetType().GetProperty("Modified").PropertyType.GenericTypeArguments[0].Name.Equals("DateTime", StringComparison.InvariantCulture))
                    {
                        object[] param = { DateTime.UtcNow };
                        entity.GetType().GetMethod("set_Modified").Invoke(entity, param);
                    }
                }
            }
            if (entity.GetType().GetMethods().Contains(entity.GetType().GetMethod("set_ModifiedByGuid")) &&
                entity.GetType().GetProperty("ModifiedByGuid").PropertyType.Name.Equals("String", StringComparison.InvariantCulture))
            {
                object[] param = { "USER" };
                // TODO get the user
                entity.GetType().GetMethod("set_ModifiedByGuid").Invoke(entity, param);
            }
            return entity;
        }

        private TEntity AddCreationData(TEntity entity)
        {
            if (entity.GetType().GetMethods().Contains(entity.GetType().GetMethod("set_Created")))
            {
                if (entity.GetType().GetProperty("Created").PropertyType.Name.Equals("String", StringComparison.InvariantCulture))
                {
                    object[] param = { DateTime.UtcNow.ToString(string.Empty, CultureInfo.InvariantCulture) };
                    entity.GetType().GetMethod("set_Created").Invoke(entity, param);
                }
                else
                {
                    if (entity.GetType().GetProperty("Created").PropertyType.Name.Equals("DateTime", StringComparison.InvariantCulture) ||
                        (entity.GetType().GetProperty("Created").PropertyType.GenericTypeArguments.Length > 0 &&
                        entity.GetType().GetProperty("Created").PropertyType.GenericTypeArguments[0].Name.Equals("DateTime", StringComparison.InvariantCulture)))
                    {
                        object[] param = { DateTime.UtcNow };
                        entity.GetType().GetMethod("set_Created").Invoke(entity, param);
                    }
                }
            }

            if (entity.GetType().GetMethods().Contains(entity.GetType().GetMethod("set_CreatedByGuid")) &&
                entity.GetType().GetProperty("CreatedByGuid").PropertyType.Name.Equals("String", StringComparison.InvariantCulture))
            {
                object[] param = { "USER" };
                // TODO get the user
                entity.GetType().GetMethod("set_CreatedByGuid").Invoke(entity, param);
            }
            return AddModificationData(entity);
        }
    }
}
