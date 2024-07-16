using Authorization.Messages;
using Companies.Domain;
using Companies.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Application.InternalEventHandlers
{
    public class OwnerHasBeenSignedUpHandler : INotificationHandler<UserHasBeenSignedUpMessage>
    {
        private readonly ISubscriptionTypeRepository _subscriptionTypeRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly CompanyDbContext _context;

        public OwnerHasBeenSignedUpHandler(ISubscriptionTypeRepository subscriptionTypeRepository, IOwnerRepository ownerRepository, CompanyDbContext context)
        {
            _subscriptionTypeRepository = subscriptionTypeRepository;
            _ownerRepository = ownerRepository;
            _context = context;
        }

        public async Task Handle(UserHasBeenSignedUpMessage notification, CancellationToken cancellationToken)
        {
            var subscriptionType = await _subscriptionTypeRepository.GetNormal();
            var subscription = subscriptionType.CreateSubscription(notification.UserId);
            var owner = Owner.CreateOwner(notification.UserId, subscription);

            await _ownerRepository.Add(owner);
        }
    }
}
