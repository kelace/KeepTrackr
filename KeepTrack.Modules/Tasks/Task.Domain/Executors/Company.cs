using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain.Executors
{
    public class Company : EntityBase
    {
        public string Name { get;private  set; }
        public Guid OwnerId { get; private set; }
        public Guid UserAssignedId { get; private set; }

        public Company(string name, Guid ownerId, Guid userAssignedId)
        {
            Name = name;
            OwnerId = ownerId;
            UserAssignedId = userAssignedId;
        }
    }
}
