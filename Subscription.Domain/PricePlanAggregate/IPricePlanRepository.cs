using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionAndPlan.Domain.PricePlanAggregate
{
    public interface IPricePlanRepository
    {
        Task<PricePlan> GetById(Guid id);
        Task<PricePlan> GetFree();
    }
}
