using Employees.Application.Commands.InviteEmployee;
using Employees.Application.Queries.DTOs;
using Employees.Application.Queries.GetAllEmployees;
using Employees.Domain.Base;
using Employees.Domain.InvitingEmployee.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<List<EmployeeDTO>> Get()
        {
            return await _mediator.Send<List<EmployeeDTO>>(new GetAllEmployeesQuery { });
        }

        //[HttpPost]
        //[Route("CREATEEMP")]
        //public async Task<OkObjectResult> CreateEmp(InviteEmployeeComand command)
        //{
        //    var result = await _mediator.Send<Result<InivtationResultInfo, Error>>(command);

        //    return result.Match<OkObjectResult>(x => Ok(new { success = true, email = x.Email }), x => Ok(new { succes = false, email = "" }));
        //}
    }
}
