using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.OwnerAggregate.Events.CompanyEvents
{
    public class CompanyCreatedEvent : INotification
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
