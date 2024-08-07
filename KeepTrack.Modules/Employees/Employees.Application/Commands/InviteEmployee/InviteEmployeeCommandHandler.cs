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

            var result = owner.InviteNewEmployee(request.Email, request.Name);

            if (result.IsError) return result;

            _ownerRepository.Update(owner);

            await _unitOfWork.SaveAsync();

            var mail = await GetMail(result.Value.MailId);
            result.Value.Email = mail;

            return result.Value;

        }

        private async Task<string> GetMail(Guid invitationId)
        {
            var result = string.Empty;
            try
            {
                using (var connection = new SqlConnection("Server=DESKTOP-6JEENNA;Database=KeepTrackrDB;User Id=sa;Password=sa;TrustServerCertificate=True"))
                {
                    var sql = "select m.Value from dbo.Mails m join emp.Invitation i on m.Id = i.MailId where m.Id = @Id";

                    result = await connection.QueryFirstOrDefaultAsync<string>(sql, new { Id = invitationId });
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return result;
        }
    }
}
