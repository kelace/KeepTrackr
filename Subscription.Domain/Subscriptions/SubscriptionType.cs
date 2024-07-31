using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Domain.Subscriptions
{
    public class SubscriptionType : EntityBase, IAggregateRoot
    {
        public SubscriptionType(string type)
        {
            Type = type;
        }

        public string Type { get; private set; }
    }
}
