using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.SubscriptionAggregate
{
    public interface ISubscriptionRepository
    {
        Task<Subscription> GetByOwnerId(Guid ownerId);
    }
}
