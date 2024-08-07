﻿using KeepTrack.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagment.Application.Commands.AddCard;
using TaskManagment.Application.Commands.ReorderCard;
using TaskManagment.Domain.Cards;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagment.Api.Controllers
{
    [Route("api/tasks/boards/cards")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TaskCardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskCardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> Put(ReorderCardCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddCardCommand command)
        {
            var result = await _mediator.Send<Result<Card, Error>>(command);

            IActionResult Success(Card card)
            {
                return Ok(new { success = true, card });
            }

            IActionResult Error(Error error)
            {
                return Ok(new {success = false, error = error });
            }

            return result.Match<IActionResult>(Success, Error);
        }
    }
}
