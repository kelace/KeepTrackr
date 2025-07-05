using Employees.Domain.RoleAggregate;
using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Commands.SaveCompaniesAndEmployees.Extensions
{
    public static class RoleContextExtension
    {
        public static Role GetUserRole(this IRoleContext roleContext)
        {
            var role = roleContext.GetUserRole;

            var roles = Role.GetAllRoles();

            foreach (var r in roles)
            {
                if(r == role) return r;
            }

            //foreach (var r in Enum.GetValues(typeof(RoleType)))
            //{
            //    if (r.ToString() == role) return (RoleType)r;

            //}

            throw new Exception("User cannot have no roles");

        }
    }
}
