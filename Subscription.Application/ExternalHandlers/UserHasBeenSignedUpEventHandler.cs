using Authorization.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Application.ExternalHandlers
{
    public class UserHasBeenSignedUpEventHandler : INotificationHandler<UserHasBeenSignedUpMessage>
    {
        public Task Handle(UserHasBeenSignedUpMessage notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
