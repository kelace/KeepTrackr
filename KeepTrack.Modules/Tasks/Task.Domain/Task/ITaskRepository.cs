using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain
{
    public interface ITaskRepository
    {
        Task<CardTask> Get(Guid id);
        void Update(CardTask task);
        System.Threading.Tasks.Task AddAsync(CardTask task);
    }
}
