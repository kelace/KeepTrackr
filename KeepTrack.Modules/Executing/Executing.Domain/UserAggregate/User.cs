using Executing.Domain.PermissionAggregate;
using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executing.Domain.UserAggregate
{
    public class User
    {
        //public Role Role { get; set; }
        //public Permission AdditionalPermission { get; set; }
        public List<PermissionId> Permission { get; set; }

        public void Update(Permission permission)
        {


        }


    }
}
