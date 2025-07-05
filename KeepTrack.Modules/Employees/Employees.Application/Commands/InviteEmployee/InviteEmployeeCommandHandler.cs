using Dapper;
using Employees.Domain;
using Employees.Domain.InvitingEmployee;
using Employees.Domain.InvitingEmployee.Result;
using Employees.Domain.OwnerAggregate;
using Employees.Domain.PricePlanAggregate;
using Employees.Domain.RoleAggregate;
using Employees.Domain.SubscriptionAggregate;
using KeepTrack.Common;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Employees.Application.Commands.InviteEmployee
{
    public class InviteEmployeeCommandHandler : IRequestHandler<InviteEmployeeComand, Result<Employee, KeepTrack.Common.Error>>
    {
        private IOwnerRepository _ownerRepository;
        private IUserContext _userContext;
        private IUnitOfWork _unitOfWork;
        private IPricePlanRepository _pricePlanRepository;
        private ISubscriptionRepository _subscriptionRepository;
        private IRoleRepository _roleRepository;
        public InviteEmployeeCommandHandler(IOwnerRepository ownerRepository, IUserContext userContext, IUnitOfWork unitOfWork, IPricePlanRepository pricePlanRepository, ISubscriptionRepository subscriptionRepository)
        {
            _ownerRepository = ownerRepository;
            _userContext = userContext;
            _unitOfWork = unitOfWork;
            _pricePlanRepository = pricePlanRepository;
            _subscriptionRepository = subscriptionRepository;
        }
        public async Task<Result<Employee, KeepTrack.Common.Error>> Handle(InviteEmployeeComand request, CancellationToken cancellationToken)
        {
            var currentUserId = _userContext.GetCrrentUserId;
            var owner = await _ownerRepository.GetAsync(currentUserId);
            var subscription = await _subscriptionRepository.GetByOwnerId(owner.Id);
            var pricePlan = await _pricePlanRepository.GetById(subscription.PricePlanId);
            var defaultEmployeeRole = await _roleRepository.GetEmployeeRole();

            var result = owner.InviteNewEmployee(request.Email, request.Name, request.CompanyId, pricePlan, subscription, defaultEmployeeRole);

            if (result.IsError) return result;

            _ownerRepository.Update(owner);

            await _unitOfWork.SaveAsync();

            return result;

        }
    }
}
