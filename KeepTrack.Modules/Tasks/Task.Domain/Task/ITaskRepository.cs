using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain
{
    public interface ITaskRepository
    {
        Task<Task> Get(Guid id);
        void Update(Task task);
        System.Threading.Tasks.Task AddAsync(Task task);
    }
}
