using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Boards;

namespace TaskManagment.Application.Commands.ReorderBoards
{
    public class ReorderBoardsCommandHandler : IRequestHandler<ReorderBoardsCommand>
    {
        private readonly IColumnRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;

        public ReorderBoardsCommandHandler(IColumnRepository boardRepository, IUnitOfWork unitOfWork, IUserContext userContext)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
            _userContext = userContext;
        }
        public async System.Threading.Tasks.Task Handle(ReorderBoardsCommand request, CancellationToken cancellationToken)
        {
            var boards = await _boardRepository.GetBoardsAsync(_userContext.GetCrrentUserId, request.Company);

            if (request.DestinationOrder == request.SourceOrder) return;
            if (request.DestinationOrder > boards.Count || request.DestinationOrder < 0) return;
            if (request.SourceOrder  > boards.Count || request.SourceOrder < 0) return;

            if(request.DestinationOrder > request.SourceOrder)
            {
                
                foreach (var item in boards)
                {
                    if (item.Order > request.DestinationOrder) break;
                    if (item.Id == request.BoardId)
                    {
                        item.Reorder(request.DestinationOrder);
                        continue;
                    };

                    if (item.Order > request.DestinationOrder || item.Order < request.SourceOrder) continue;

                    item.Reorder(item.Order - 1);
                }

            } 
            else
            {
                foreach (var item in boards)
                {
                    if (item.Order > request.SourceOrder) break;
                    if (item.Id == request.BoardId)
                    {
                        item.Reorder(request.DestinationOrder);
                        continue;
                    }

                    if (item.Order < request.DestinationOrder || item.Order > request.SourceOrder) continue;

                    item.Reorder(item.Order + 1);
                }
            }

            //foreach (var item in boards)
            //{
            //    var b = request.Boards.FirstOrDefault(x => x.Key == item.Id);
            //    item.Reorder(b.Value);
            //}

            //var board = boards.FirstOrDefault(x => x.Id == request.BoardId);

            //board.Reorder(request.Order);

            //for (var i = 0; boards.Count > i; i++ )
            //{
            //    if (boards[i].Id == request.BoardId) break;

            //    boards[i].Reorder(--i);
            //}

            _boardRepository.UpdateRange(boards);
            await _unitOfWork.SaveAsync();

        }


    }
}
