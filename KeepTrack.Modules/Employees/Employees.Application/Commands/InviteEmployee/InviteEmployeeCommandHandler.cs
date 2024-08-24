using Dapper;
using Employees.Domain;
using Employees.Domain.Base;
using Employees.Domain.InvitingEmployee;
using Employees.Domain.InvitingEmployee.Result;
using KeepTrack.Common;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Employees.Application.Commands.InviteEmployee
{
    public class InviteEmployeeCommandHandler : IRequestHandler<InviteEmployeeComand, Result<InivtationResultInfo, KeepTrack.Common.Error>>
    {
        private IOwnerRepository _ownerRepository;
        private IUserContext _userContext;
        private IUnitOfWork _unitOfWork;
        public InviteEmployeeCommandHandler(IOwnerRepository ownerRepository, IUserContext userContext, IUnitOfWork unitOfWork)
        {
            _ownerRepository = ownerRepository;
            _userContext = userContext;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<InivtationResultInfo, KeepTrack.Common.Error>> Handle(InviteEmployeeComand request, CancellationToken cancellationToken)
        {
            var currentUserId = _userContext.GetCrrentUserId;
            var owner = await _ownerRepository.GetAsync(currentUserId);

            var result = owner.InviteNewEmployee(request.Email, request.Name, request.Companies);

            if (result.IsError) return result;

            _ownerRepository.Update(owner);

            await _unitOfWork.SaveAsync();

            return result.Value;

        }
    }
}
