using Companies.Messages;
using Employees.Domain;
using Employees.Domain.InvitingEmployee;
using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.ExternalEventHandlers
{
    public class CompanyHasBeenAddedEventHandler : INotificationHandler<CompanyHasBeenAddedExternalEvent>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CompanyHasBeenAddedEventHandler(IOwnerRepository ownerRepository, IUnitOfWork unitOfWork)
        {
            _ownerRepository = ownerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CompanyHasBeenAddedExternalEvent notification, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetAsync(notification.OwnerId);

            owner.AddCompany(notification.CompanyName);

            _ownerRepository.Update(owner);
        }
    }
}
