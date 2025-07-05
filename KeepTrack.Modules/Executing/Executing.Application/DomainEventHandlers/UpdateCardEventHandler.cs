using Executing.Domain.CardAggregate;
using Executing.Domain.CardAggregate.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executing.Application.DomainEventHandlers
{
    public class UpdateCardEventHandler : INotificationHandler<UpdateCardEvent>
    {
        ICardRepository _cardRepository;

        public UpdateCardEventHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async System.Threading.Tasks.Task Handle(UpdateCardEvent notification, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.Get(notification.CardId);
            var cardCount = await _cardRepository.GetCardsCountByColumn(notification.ColumnId);

            //var reorderService = Reo
            throw new NotImplementedException();
        }
    }
}
