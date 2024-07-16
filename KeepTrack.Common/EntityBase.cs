using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepTrack.Common
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
        public List<INotification> Events { get; private set; } = new List<INotification>();

        public void ClearEvents()
        {
            Events = new List<INotification>();
        }
        public void AddEvent(INotification @event)
        {
            if (@event is null) return;

            Events.Add(@event);
        }
    }
}
