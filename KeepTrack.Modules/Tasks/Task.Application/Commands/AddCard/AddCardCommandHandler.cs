using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Boards;
using TaskManagment.Domain.Cards;

namespace TaskManagment.Application.Commands.AddCard
{
    public class AddCardCommandHandler : IRequestHandler<AddCardCommand, Result<Card, Error>>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUserContext _userContext;
        private readonly IUnitOfWork _unitOfWork;

        public AddCardCommandHandler(ICardRepository cardRepository, IUserContext userContext, IUnitOfWork unitOfWork)
        {
            _cardRepository = cardRepository;
            _userContext = userContext;
            _unitOfWork = unitOfWork;
        }

        public async System.Threading.Tasks.Task<Result<Card, Error>> Handle(AddCardCommand request, CancellationToken cancellationToken)
        {
            var card = Card.CreateCard(request.Title, request.CompanyName, _userContext.GetCrrentUserId, request.Order, request.BoardId);

            await _cardRepository.Add(card);

            await _unitOfWork.SaveAsync();

            return card;
        }
    }
}
