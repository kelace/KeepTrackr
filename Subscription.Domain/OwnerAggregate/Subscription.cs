using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Domain.OwnerAggregate
{
    public class Subscription : EntityBase
    {
        public Guid PricePlanId { get; private set; }
        public Guid OwnerId { get; private set; }
        public DateTime? From { get; private set; }
        public DateTime? To { get; private set; }

        public Subscription(Guid pricePlanId, Guid ownerId, DateTime? from, DateTime? to)
        {
            PricePlanId = pricePlanId;
            OwnerId = ownerId;
            From = from;
            To = to;
        }

        public void ChangePlan(Guid planId)
        {
            PricePlanId = planId;
        }
    }
}
