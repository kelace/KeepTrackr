using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Cards;

namespace TaskManagment.Application.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICardRepository _cardRepository;

        public CreateTaskCommandHandler(IUnitOfWork unitOfWork, ICardRepository cardRepository)
        {
            _unitOfWork = unitOfWork;
            _cardRepository = cardRepository;
        }

        public async System.Threading.Tasks.Task Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.Get(request.CardId);

            card.AddTask(request.TaskName);

            _cardRepository.Update(card);

            await _unitOfWork.SaveAsync();
        }
    }
}
