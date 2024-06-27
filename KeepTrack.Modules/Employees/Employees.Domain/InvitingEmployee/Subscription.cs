using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.InvitingEmployee
{
    public class Subscription
    {
        public SubscriptionType Type { get; private set; }
        public int AllowedEmployeePerType { get; private set; }
    }

    public enum SubscriptionType
    {
        Free,
        Normal,
        Gold
    }
}
