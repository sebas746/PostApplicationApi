using PostApplication.DataContext.PostApplication;
using PostApplication.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PostApplicationContext dbContext;

        public UnitOfWork(PostApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private IPostRepository _Post;

        public IPostRepository Post
        {
            get
            {
                if (this._Post == null)
                {
                    this._Post = new PostRepository(dbContext);
                }
                return this._Post;
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
        public int Complete()
        {
            return dbContext.SaveChanges();
        }
        public void Dispose() => dbContext.Dispose();
    }
}
