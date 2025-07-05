using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.OwnerAggregate
{
    public class Company : EntityBase
    {
        public string CompanyName { get; private set; }
        public List<Employee> Employees { get; private set; }
        public Guid OwnerId { get; private set; }

        public Company(Guid id, string name)
        {
            Id = id;
            CompanyName = name;
        }

        public void ChangeName(string name)
        {
            CompanyName = name;
        }
    }
}
