using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Domain.OwnerAggregate
{
    public interface IOwnerRepository
    {
        Task<Owner> Get(Guid id);
        void Update(object user);
    }
}
