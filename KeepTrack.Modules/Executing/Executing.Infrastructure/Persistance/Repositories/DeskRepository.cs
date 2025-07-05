using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Executing.Domain.Companies;
using Executing.Domain.DeskAggregate;

namespace Executing.Infrastructure.Persistance.Repositories
{
    public class DeskRepository : IDeskRepository
    {
        private readonly TaskContext _context;
        public DeskRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Desk company)
        {
            await _context.Companies.AddAsync(company);
        }

        public async Task<Desk> Get(string name, Guid ownerId)
        {
            return await _context.Companies.Where(x => x.CompanyName == name && x.OwnerId == ownerId).FirstOrDefaultAsync();
        }

        public void Update(Desk company)
        {
            _context.Companies.Update(company);
        }
    }
}
