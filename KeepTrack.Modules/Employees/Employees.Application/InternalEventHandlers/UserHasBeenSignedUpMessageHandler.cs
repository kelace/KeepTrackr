﻿using Authorization.Messages;
using Employees.Domain;
using Employees.Domain.InvitingEmployee;
using MediatR;

namespace Employees.Application.InternalEventHandlers
{
    public class UserHasBeenSignedUpMessageHandler : INotificationHandler<UserHasBeenSignedUpMessage>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserHasBeenSignedUpMessageHandler(IOwnerRepository ownerRepository, IUnitOfWork unitOfWork)
        {
            _ownerRepository = ownerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UserHasBeenSignedUpMessage notification, CancellationToken cancellationToken)
        {
            var newOwner = new Owner(notification.UserId);
            await _ownerRepository.AddAsync(newOwner);
            await _unitOfWork.SaveAsync();
        }
    }
}
