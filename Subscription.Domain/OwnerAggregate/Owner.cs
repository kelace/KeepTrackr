using KeepTrack.Common;
using Subscription.Domain.PricePlanAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Domain.OwnerAggregate
{
    public class Owner : EntityBase, IAggregateRoot
    {
        public Subscription Subscription { get; private set; }
        public Owner()
        {

        }

        public Owner(Guid id, PricePlan pricePlan)
        {
            Id = id;
            if(pricePlan.Value == "Free") {
                Subscription = new Subscription(Guid.NewGuid(), pricePlan.Id, null, null);
            }
        }

        public void ChangeSubscriptionPlan(Guid planId)
        {
            Subscription.ChangePlan(planId);
        }
    }
}
