using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain;

namespace TaskManagment.Infrastructure.Persistance.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }
        public async System.Threading.Tasks.Task AddAsync(Domain.CardTask task)
        {
            _context.Tasks.Add(task);
        }

        public async Task<Domain.CardTask> Get(Guid id)
        {
            return await _context.Tasks.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Update(Domain.CardTask task)
        {
            _context.Tasks.Update(task);
        }
    }
}
