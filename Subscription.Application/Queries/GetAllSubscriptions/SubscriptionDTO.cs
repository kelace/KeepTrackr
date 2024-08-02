using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Application.Queries.GetAllSubscriptions
{
    public class SubscriptionDTO
    {
        public string Type { get; set; }
        public bool IsSubscribed { get; set; }
    }
}
