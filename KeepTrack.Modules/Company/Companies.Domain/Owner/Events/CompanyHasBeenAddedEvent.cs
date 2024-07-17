using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Domain.Events
{
    public class CompanyHasBeenAddedEvent : INotification
    {
        public string CompanyName { get; set; }
        public Guid OwnerId { get; set; }
    }
}
