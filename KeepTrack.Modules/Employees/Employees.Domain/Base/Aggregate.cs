using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.Base
{
    public abstract class AggregateRoot : Entity
    {
        public List<DomainEvent> Events { get; private set; }

        public AggregateRoot()
        {
            Events = new List<DomainEvent>();
        }

        public AggregateRoot(Guid Id) : base(Id) 
        {
            Events = new List<DomainEvent>();
        }

        public void AddEvent(DomainEvent @event)
        {
            Events.Add(@event);
        }

        public void AddRangeEvent(List<DomainEvent> @events)
        {
            Events.AddRange(@events);
        }

        public List<DomainEvent> GetEvents()
        {
            return Events.ToList();
        }

        public void ClearEvents()
        {
            Events = new List<DomainEvent>();
        }
    }
}
