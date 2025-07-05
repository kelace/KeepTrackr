using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.OwnerAggregate.Events.EmployeeEvents
{
    public class EmployeeModifiedEvent : INotification
    {
        public Guid RoleId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
