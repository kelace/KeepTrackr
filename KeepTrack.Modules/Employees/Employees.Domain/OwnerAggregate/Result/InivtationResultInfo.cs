using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.InvitingEmployee.Result
{
    public class InivtationResultInfo
    {
        public string Email { get; set; }
        public Guid MailId { get; set; }
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
    }
}
