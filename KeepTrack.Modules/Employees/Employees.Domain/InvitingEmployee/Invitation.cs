using Employees.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.InvitingEmployee
{
    public class Invitation : Entity
    {
        public  Guid EmployeeId { get; set; }
        public Guid MailId { get; set; }
    }
}
