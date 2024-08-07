using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Cards;

namespace TaskManagment.Application.Commands.ReorderCard
{
    public class ReorderCardCommandHandler : IRequestHandler<ReorderCardCommand>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUserContext _userContext;
        private readonly IUnitOfWork _unitOfWork;

        public ReorderCardCommandHandler(ICardRepository cardRepository, IUserContext userContext, IUnitOfWork unitOfWork)
        {
            _cardRepository = cardRepository;
            _userContext = userContext;
            _unitOfWork = unitOfWork;
        }

        public async System.Threading.Tasks.Task Handle(ReorderCardCommand request, CancellationToken cancellationToken)
        {
            var cards = await _cardRepository.GetBoardsAsync(_userContext.GetCrrentUserId, request.Company);
            var changedCard = cards.Where(x => x.Id == request.CardId).FirstOrDefault();

            if (request.DestinationOrder == request.SourceOrder) return;
            if (request.DestinationOrder > cards.Count || request.DestinationOrder < 0) return;
            if (request.SourceOrder > cards.Count || request.SourceOrder < 0) return;

            if (request.BoardId == changedCard.BoardId)
            {

                var cardsInBoard = cards.Where(x => x.BoardId == changedCard.BoardId).ToList();

                if (request.DestinationOrder > request.SourceOrder)
                {

                    foreach (var item in cardsInBoard)
                    {
                        if (item.Order > request.DestinationOrder) break;
                        if (item.Id == request.CardId)
                        {
                            item.Reorder(request.DestinationOrder);
                            //if(item.BoardId != request.BoardId) item.ChangeBoard(request.BoardId);
                            continue;
                        };

                        if (item.Order > request.DestinationOrder || item.Order < request.SourceOrder) continue;

                        item.Reorder(item.Order - 1);
                    }

                }

                else
                {
                    foreach (var item in cardsInBoard)
                    {
                        if (item.Order > request.SourceOrder) break;
                        if (item.Id == request.CardId)
                        {
                            item.Reorder(request.DestinationOrder);
                            //if (item.BoardId != request.BoardId) item.ChangeBoard(request.BoardId);
                            continue;
                        }

                        if (item.Order < request.DestinationOrder || item.Order > request.SourceOrder) continue;

                        item.Reorder(item.Order + 1);
                    }
                }
                //return;
            } else
            {
                changedCard.ChangeBoard(request.BoardId);
                changedCard.Reorder(request.DestinationOrder);

                var cardsInNewBoard = cards.Where(x => x.BoardId == request.BoardId && x.Id != changedCard.Id).ToList();
                var cardsInOldBoard = cards.Where(x => x.BoardId == changedCard.BoardId && x.Id != changedCard.Id).ToList();

                foreach (var item in cardsInOldBoard)
                {

                    if (item.Order < request.SourceOrder) continue;

                    item.Reorder(item.Order - 1);

                }



                foreach (var item in cardsInNewBoard)
                {

                    if (item.Order < request.DestinationOrder) continue;

                    item.Reorder(item.Order + 1);
                }
            }

           

            _cardRepository.UpdateRange(cards);


            await _unitOfWork.SaveAsync();
        }
    }
}
