using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.RoleAggregate
{
    public class Role : EntityBase, IAggregateRoot
    {
        //public RoleType Type { get; private set; }
        public string Value { get; private set; }

        public bool IsOwner => Value == Role.Owner;
        public bool IsNotOwner => Value != Role.Owner;

        //public static Role Owner => new Role();
        //public static Role Administrator => new Role();

        public Role(string value)
        {

        }


        public static Role Owner => new Role("Owner");
        public static Role Administrator => new Role("Administrator");
        public static Role Moderator => new Role("Moderator");
        public static Role Employee => new Role("Employee");

        public static List<Role> GetAllRoles()
        {
            var roles = new List<Role>()
            {
                Role.Owner,
                Role.Administrator,
                Role.Moderator,
                Role.Employee,
            };

            return roles;
        }

    }

    //public class RoleType
    //{
    //    public RoleType(string value)
    //    {
    //        Value = value;
    //    }

    //    public string Value { get; private set; }
    //    public static RoleType Owner => new RoleType("Owner");
    //    public static RoleType Administrator => new RoleType("Administrator");
    //}

    public enum RoleType
    {
        Administrator,
        Owner,
        Moderator,
        Employee
    }
}
