using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Subscription.Application.Commands.SubscribeUser;
using Subscription.Application.Queries.GetAllSubscriptions;

namespace Subscription.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> Put(SubscribeUserCommand command)
        {
            await _mediator.Send(command);

            return Ok(new {type = command.Type});
        }

        [HttpGet]
        public async Task<List<SubscriptionDTO>> Get()
        {
            return await _mediator.Send<List<SubscriptionDTO>>( new GetAllSubscriptionsQuery());
        }
    }
}
