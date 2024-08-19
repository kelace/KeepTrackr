using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagment.Application.Commands.CreateLabel;

namespace TaskManagment.Api.Controllers
{
    [Route("api/tasks/cards/labels")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class LabelsController : ControllerBase
    {

        private IMediator _mediator;

        public LabelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateLabelCommand command)
        {
            await _mediator.Send(command);

            return Ok(new {success = true});
        }
    }
}
