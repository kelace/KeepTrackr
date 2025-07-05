using KeepTrack.Common;
using KeepTrackr.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionAndPlan.Domain.PricePlanAggregate
{
    public class PricePlan : EntityBaseWithCustomId, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public PricePlanType SubscriptionType { get; private set; }
        public int Price { get; private set; }
        public string Value { get; private set; }
    }
}
