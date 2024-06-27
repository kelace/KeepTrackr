using Employees.Domain.InvitingEmployee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private EmployeeDbContext _context;
        public OwnerRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<Owner> GetAsync(Guid id)
        {
            return  await _context.Owners.Include(x => x.Employees).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Owner owner)
        {
            await _context.AddAsync(owner);
        }

        public  void Update(Owner owner)
        {
            _context.Owners.Update(owner);
        }
    }
}
