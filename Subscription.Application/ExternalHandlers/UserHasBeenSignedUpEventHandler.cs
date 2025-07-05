using Authorization.Messages;
using MediatR;
using Subscription.Domain.OwnerAggregate;
using Subscription.Domain.PricePlanAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionAndPlan.Application.ExternalHandlers
{
    public class UserHasBeenSignedUpEventHandler : INotificationHandler<UserHasBeenSignedUpMessage>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPricePlanRepository _pricePlanRepository;

        public UserHasBeenSignedUpEventHandler(IOwnerRepository ownerRepository, IPricePlanRepository pricePlanRepository)
        {
            _ownerRepository = ownerRepository;
            _pricePlanRepository = pricePlanRepository;
        }

        public async Task Handle(UserHasBeenSignedUpMessage notification, CancellationToken cancellationToken)
        {
        
            var plan = await _pricePlanRepository.GetFree();

            var owner = new Owner(notification.UserId, plan.Id);
            //owner.ChangeSubscriptionPlan(plan.Id);

            await ow.AddAsync(user);
        }
    }
}
