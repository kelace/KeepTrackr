using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Companies;

namespace TaskManagment.Infrastructure.Persistance.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly TaskContext _context;
        public CompanyRepository(TaskContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

        public async Task<Company> Get(string name, Guid ownerId)
        {
            return await _context.Companies.Where(x => x.CompanyName == name && x.OwnerId == ownerId).FirstOrDefaultAsync();
        }

        public void Update(Company company)
        {
            _context.Companies.Update(company);
        }
    }
}
