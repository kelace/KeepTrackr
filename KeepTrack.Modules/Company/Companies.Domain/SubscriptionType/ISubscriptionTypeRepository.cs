using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Domain
{
    public interface ISubscriptionTypeRepository
    {
        Task<SubscriptionType> Get(string type);
        Task<SubscriptionType> GetNormal();
    }
}
