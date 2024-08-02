using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagment.Application.Commands.AddBoard;
using TaskManagment.Application.Commands.AddTask;
using TaskManagment.Application.Commands.ReorderBoards;
using TaskManagment.Application.Commands.UpdateBoard;
using TaskManagment.Application.Queries.GetAllBoardsInfo;
using TaskManagment.Application.Queries.GetAllBoardsInfo.DTOs;

namespace TaskManagment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("boards")]
        public async System.Threading.Tasks.Task<List<BoardDTO>> Boards(string company)
        {
            return await _mediator.Send<List<BoardDTO>>(new GetAllBoardsInfoQuery
            {
                CompanyName = company
            });
        } 

        [HttpPost]
        [Route("boards")]
        public async System.Threading.Tasks.Task<IActionResult> Boards(AddBoardCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        [Route("boards")]
        public async System.Threading.Tasks.Task<IActionResult> Boards(UpdateBoardCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }


        [HttpPut]
        [Route("boards/order")]
        public async System.Threading.Tasks.Task<IActionResult> Boards(ReorderBoardsCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
