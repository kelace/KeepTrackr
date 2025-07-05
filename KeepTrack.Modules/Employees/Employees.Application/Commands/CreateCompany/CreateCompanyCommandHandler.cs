using Employees.Domain.ManagerAggregate;
using Employees.Domain.OwnerAggregate;
using Employees.Domain.PricePlanAggregate;
using Employees.Domain.RoleAggregate;
using Employees.Domain.SubscriptionAggregate;
using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Result<Company, Error>>
    {
        IOwnerRepository _ownerRepository;
        ISubscriptionRepository _subscriptionRepository;
        IManagerRepository _managerRepository;
        IRoleRepository _roleRepository;
        IOwnerContext _ownerContext;
        IRoleContext _roleContext;
        IUnitOfWork _unitOfWork;
        IPricePlanRepository _pricePlanRepository;

        public CreateCompanyCommandHandler(IOwnerRepository ownerRepository, ISubscriptionRepository subscriptionRepository, IManagerRepository managerRepository, IRoleRepository roleRepository, IOwnerContext ownerContext, IRoleContext roleContext, IUnitOfWork unitOfWork, IPricePlanRepository pricePlanRepository)
        {
            _ownerRepository = ownerRepository;
            _subscriptionRepository = subscriptionRepository;
            _managerRepository = managerRepository;
            _roleRepository = roleRepository;
            _ownerContext = ownerContext;
            _roleContext = roleContext;
            _unitOfWork = unitOfWork;
            _pricePlanRepository = pricePlanRepository;
        }

        public async Task<Result<Company, Error>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var ownerId = _ownerContext.OwnerId;
            var owner = await _ownerRepository.GetById(ownerId);
            var subscription = await _subscriptionRepository.GetByOwnerId(ownerId);
            var pricePlan = await _pricePlanRepository.GetById(subscription.PricePlanId);

            return owner.RegisterCompany(request.Name, pricePlan, subscription);
        }
    }
}
