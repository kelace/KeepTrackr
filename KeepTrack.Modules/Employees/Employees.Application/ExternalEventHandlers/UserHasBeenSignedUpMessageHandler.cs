using Authorization.Messages;
using Employees.Domain;
using Employees.Domain.InvitingEmployee;
using KeepTrack.Common;
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
            var newOwner = Owner.CreateOwner(notification.UserId);
            await _ownerRepository.AddAsync(newOwner);
        }
    }
}
