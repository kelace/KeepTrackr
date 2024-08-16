using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Boards;

namespace TaskManagment.Application.Commands.UpdateBoard
{
    public class UpdateBoardCommandHandler : IRequestHandler<UpdateBoardCommand>
    {
        private readonly IColumnRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;

        public UpdateBoardCommandHandler(IColumnRepository boardRepository, IUnitOfWork unitOfWork, IUserContext userContext)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
            _userContext = userContext;
        }

        public async System.Threading.Tasks.Task Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.Get(request.Id);

            board.Update(request.Name, request.Order);

            _boardRepository.Update(board);

            await _unitOfWork.SaveAsync();
        }
    }
}
