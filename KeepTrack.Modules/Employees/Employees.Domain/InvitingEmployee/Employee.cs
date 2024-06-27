using Employees.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.InvitingEmployee
{
    public class Employee : Entity
    {
        public Employee(Guid id) : base(id)
        {

        }
        public Guid OwnerId { get;  set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        //public Company? Company { get; private set; }

        //public Employee(Guid id, Guid ownerId, string name, string email) 
        //{
        //    Id = id;
        //    OwnerId = ownerId;
        //    Name = name;
        //    Email = email;
        //}
    }
}
