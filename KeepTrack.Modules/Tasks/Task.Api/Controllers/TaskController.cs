using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagment.Application.Commands.AddTask;

namespace TaskManagment.Api.Controllers
{
    [Route("api/[controller]/company/{company}")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> Post([FromQuery] string company,AddTaskCommand command)
        {
            command.CompanyName = company;
            await _mediator.Send(command);
            return Ok();
        }
    }
}
