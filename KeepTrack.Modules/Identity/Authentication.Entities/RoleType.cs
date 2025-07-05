using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Entities
{
    public static class RoleType
    {
        public static string Administrator => "Administrator";
        public static string Owner => "Owner";
        public static string Moderator => "Moderator";
        public static string Employee => "Employee";

    }
}
