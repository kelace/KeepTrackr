using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Domain
{
    public class SubscriptionType
    {
        public string Type { get; private set; }
        public int AllowedCompaniesCount { get; private set; }

        public SubscriptionType(string type, int allowedCompaniesCount)
        {
            Type = type;
            AllowedCompaniesCount = allowedCompaniesCount;
        }

        public Subscription CreateSubscription(Guid ownerId)
        {
            return new Subscription(ownerId, AllowedCompaniesCount);  
        }
    }
}
