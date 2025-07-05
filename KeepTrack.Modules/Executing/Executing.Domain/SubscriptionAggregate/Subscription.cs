using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executing.Domain.SubscriptionAggregate
{
    public class Subscription : EntityBase, IAggregateRoot
    {
        public int MaxLabelAllowed { get; private set; }
    }
}
