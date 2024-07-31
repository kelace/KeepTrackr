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
        public string Type { get; set; }
        public Guid UserId { get; private set; }
    }
}
