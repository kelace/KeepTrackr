using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Domain.Users
{
    public class SubscriptionItem : EntityBase
    {
        public string Type { get; private set; }
        public Guid UserId { get; private set; }

        public SubscriptionItem(string type, Guid userId)
        {
            Id = Guid.NewGuid();
            Type = type;
            UserId = userId;
        }

        public void ChangeSubscription(string type)
        {
            this.Type = type;
        }
    }

}
