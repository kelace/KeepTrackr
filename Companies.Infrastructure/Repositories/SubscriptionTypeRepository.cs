using Companies.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Infrastructure.Repositories
{
    public class SubscriptionTypeRepository : ISubscriptionTypeRepository
    {
        private readonly CompanyDbContext _context;
        public SubscriptionTypeRepository(CompanyDbContext context)
        {
            _context = context;
        }
        public async Task<SubscriptionType> Get(string type)
        {
            return await _context.SubscriptionTypes.Where(x => x.Type == type).FirstOrDefaultAsync();
        }

        public async Task<SubscriptionType> GetNormal()
        {
            return await _context.SubscriptionTypes.Where(x => x.Type == "Normal").FirstOrDefaultAsync();
        }
    }
}
