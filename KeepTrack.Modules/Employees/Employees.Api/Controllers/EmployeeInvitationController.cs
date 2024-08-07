using Employees.Application.Commands.InviteEmployee;
using Employees.Domain.Base;
using Employees.Domain.InvitingEmployee.Result;
using Employees.Infrastructure;
using KeepTrack.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

           return result.Match<OkObjectResult>(x => Ok(new { success = true, email = x.Email, employee = new { name = x.Name, mailId = x.MailId, employeeId = x.EmployeeId } }), x => Ok(new { succes = false, email = "" }));
        }
    }
}
