using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Domain.Users
{
    public class User : EntityBase, IAggregateRoot
    {
        public string Name { get; private set; }
        public SubscriptionItem SubscriptionItem { get; private set; }

    }
}
