using Employees.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.InvitingEmployee.Events
{
    public class EmployeeHasBeenInvitedEvent : DomainEvent
    {
        public Guid EmployeeId { get; set; }
        public Guid InvitationId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }    
        public string CompanyName { get; set; }
        public Guid CompanyOwnerId { get; set; }
        public Guid MailId { get; set; }
    }
}
