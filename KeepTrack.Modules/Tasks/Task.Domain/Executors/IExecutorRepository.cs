using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain.Executors
{
    public interface IExecutorRepository
    {
        Task<Executor> GetAsync(Guid id);
        System.Threading.Tasks.Task AddAsync(Executor executor);
        void Update(Executor executor);
    }
}
