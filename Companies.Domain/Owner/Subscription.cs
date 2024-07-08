using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Domain
{
    public class Subscription
    {
        public Guid Id { get; private set; }
        public Guid OwnerId { get; private set; }
        public int AllowedCompaniesCount { get; private set; }

        public Subscription( Guid ownerId, int allowedCompaniesCount)
        {
            Id = Guid.NewGuid();
            OwnerId = ownerId;
            AllowedCompaniesCount = allowedCompaniesCount;
        }
    }
}
