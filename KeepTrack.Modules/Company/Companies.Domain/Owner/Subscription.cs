using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Domain
{
    public class Subscription : EntityBase
    {
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
