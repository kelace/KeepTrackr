using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Cards;

namespace TaskManagment.Application.Commands.UpdateCard
{
    public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICardRepository _cardRepository;

        public UpdateCardCommandHandler(IUserContext userContext, IUnitOfWork unitOfWork, ICardRepository cardRepository)
        {
            _userContext = userContext;
            _unitOfWork = unitOfWork;
            _cardRepository = cardRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.Get(request.CardId);

            card.Update(request.Name, request.CompletionDate, request.AssignedUserId);

            _cardRepository.Update(card);

            await _unitOfWork.SaveAsync();
        }
    }
}
