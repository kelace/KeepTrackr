using Microsoft.EntityFrameworkCore;
using Subscription.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SubscriptionContext _context;

        public UserRepository(SubscriptionContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> Get(Guid id)
        {
            return await _context.Users.Include(x => x.SubscriptionItem).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
