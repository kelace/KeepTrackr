using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.OwnerAggregate.Events.EmployeeEvents
{
    public class EmployeeHasBeenInvitedEvent : INotification
    {
        public Guid EmployeeId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
    }
}
