using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executing.Domain
{
    public interface IJobRepository
    {
        Task<Job> Get(Guid id);
        void Update(Job task);
        System.Threading.Tasks.Task AddAsync(Job task);
    }
}
