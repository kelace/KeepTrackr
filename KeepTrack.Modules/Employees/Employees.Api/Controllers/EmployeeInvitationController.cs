﻿using Dapper;
using Employees.Application.Commands.InviteEmployee;
using Employees.Domain.Base;
using Employees.Domain.InvitingEmployee.Result;
using Employees.Infrastructure;
using KeepTrack.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Employees.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/employee/invitation")]
    public class EmployeeInvitationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeInvitationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<OkObjectResult> Post(InviteEmployeeComand command)
        {
            var result =  await _mediator.Send<Result<InivtationResultInfo, KeepTrack.Common.Error>>(command);
            var email = await GetMail(result.Value.MailId);

           return result.Match<OkObjectResult>(x => Ok(new { success = true, email = email, employee = new { name = x.Name, mailId = x.MailId, employeeId = x.EmployeeId } }), x => Ok(new { succes = false, email = "" }));
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
