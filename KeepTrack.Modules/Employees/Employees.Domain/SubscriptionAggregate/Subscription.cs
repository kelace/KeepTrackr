using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.SubscriptionAggregate
{
    public class Subscription : EntityBase
    {
        public Guid PricePlanId { get; private set; }
        public Guid OwnerId { get; private set; }
        //public SubscriptionType Type { get; private set; }
        public void ChangepricePlan(Guid pricePlanId )
        {
            PricePlanId = pricePlanId;
        }

    }
}
