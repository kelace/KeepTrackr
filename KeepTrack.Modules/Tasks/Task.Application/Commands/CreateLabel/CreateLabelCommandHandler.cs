using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Cards;

namespace TaskManagment.Application.Commands.CreateLabel
{
    public class CreateLabelCommandHandler : IRequestHandler<CreateLabelCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICardRepository _cardRepository;

        public CreateLabelCommandHandler(IUserContext userContext, IUnitOfWork unitOfWork, ICardRepository cardRepository)
        {
            _userContext = userContext;
            _unitOfWork = unitOfWork;
            _cardRepository = cardRepository;
        }

        public async System.Threading.Tasks.Task Handle(CreateLabelCommand request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.Get(request.CardId);
            
            card.AddLabel(request.Title, request.Color);

            _cardRepository.Update(card);

            await _unitOfWork.SaveAsync();
        }
    }
}
