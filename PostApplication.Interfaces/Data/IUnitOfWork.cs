using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.Interfaces.Data
{
    public interface IUnitOfWork
    {
        IPostRepository Post { get; }        
        Task<int> CompleteAsync();
        int Complete();
    }
}
