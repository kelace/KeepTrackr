using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Domain
{
    public class Company
    {
        public string Name { get; private set; }
        public Guid OwnerId { get; private set; }

        public Company(string name, Guid ownerId)
        {
            Name = name;
            OwnerId = ownerId;
        }
    }
}
