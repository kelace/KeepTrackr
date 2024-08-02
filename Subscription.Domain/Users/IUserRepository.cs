using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Domain.Users
{
    public interface IUserRepository
    {
        Task<User> Get(Guid id);
        Task AddAsync(User user);
        void Update(User user);
    }
}
