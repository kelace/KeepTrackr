using Companies.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly CompanyDbContext _context;
        public OwnerRepository(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task Add(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
        }

        public async Task<Owner> Get(Guid id)
        {
            return await _context.Owners.Include(x => x.Subscription).Include(x => x.Companies).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Update(Owner owner)
        {
            _context.Update(owner);
        }
    }
}
