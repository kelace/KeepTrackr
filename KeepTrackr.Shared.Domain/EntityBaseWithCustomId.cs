using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepTrackr.Shared.Domain
{
    public class EntityBaseWithCustomId 
    {
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
