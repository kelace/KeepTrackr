using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Application.Commands.SubscribeUser
{
    public class SubscribeUserCommandHandler : IRequestHandler<SubscribeUserCommand>
    {
        public Task Handle(SubscribeUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
