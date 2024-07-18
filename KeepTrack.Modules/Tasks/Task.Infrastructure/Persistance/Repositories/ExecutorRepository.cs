using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain;

namespace TaskManagment.Infrastructure.Persistance.Repositories
{
    public class ExecutorRepository : IExecutorRepository
    {
        private readonly TaskContext _context;

        public ExecutorRepository(TaskContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task AddAsync(Executor executor)
        {
            await _context.Executors.AddAsync(executor);
        }

        public async Task<Executor> GetAsync(Guid id)
        {
            return await _context.Executors.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Update(Executor executor)
        {
            _context.Executors.Update(executor);
        }
    }
}
