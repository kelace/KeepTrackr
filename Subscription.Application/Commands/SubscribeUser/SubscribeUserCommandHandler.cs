using KeepTrack.Common;
using MediatR;
using Subscription.Domain.OwnerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionAndPlan.Application.Commands.SubscribeUser
{
    public class SubscribeUserCommandHandler : IRequestHandler<SubscribeUserCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SubscribeUserCommandHandler(IUserContext userContext, IOwnerRepository ownerRepository, IUnitOfWork unitOfWork)
        {
            _userContext = userContext;
            _ownerRepository = ownerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(SubscribeUserCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.Get(_userContext.GetCrrentUserId);

            owner.ChangeSubscriptionPlan(request.PlanId);

            _ownerRepository.Update(owner);

            await _unitOfWork.SaveAsync();
        }
    }
}
