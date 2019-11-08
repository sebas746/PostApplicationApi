using Microsoft.EntityFrameworkCore;
using PostApplication.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApplication.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
