using Employees.Domain.RoleAggregate;
using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.ManagerAggregate
{
    public class Manager : EntityBase
    {
        public ManagerId Id { get; private set; }
        public Guid RoleId { get; private set; }
        public bool CanAssignEmployeeToRole(List<Role> roles)
        {
            var role = GetManagerRole(roles);

            if(role.Type == RoleType.Administrator) return true;
            return false;
        }

        //public bool CanRegisterCompany(Role role)
        //{

        //}

        private Role GetManagerRole(List<Role> roles)
        {
            return roles.First(x => x.Id == RoleId);
        }
    }
}
