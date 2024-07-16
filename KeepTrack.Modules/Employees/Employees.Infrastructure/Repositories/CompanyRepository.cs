using Employees.Domain.Company;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly EmployeeDbContext _context;
        public CompanyRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task Add(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

        public Task<Company> Get(string name)
        {
            return _context.Companies.Where(x => x.CompanyName == name).FirstOrDefaultAsync();
        }

        public void Update(Company company)
        {
            _context.Companies.Update(company);
        }
    }
}
