using Companies.Domain.Events;
using Companies.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Application.EventsHandler
{
    public class CompanyHasBeenAddedEventHandler : INotificationHandler<CompanyHasBeenAddedEvent>
    {
        private readonly IMediator _mediator;
        public CompanyHasBeenAddedEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(CompanyHasBeenAddedEvent notification, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new CompanyHasBeenAddedExternalEvent
            {
                CompanyName = notification.CompanyName
            });
        }
    }
}
