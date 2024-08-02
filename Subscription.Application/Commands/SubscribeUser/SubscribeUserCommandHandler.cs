using KeepTrack.Common;
using MediatR;
using Subscription.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Application.Commands.SubscribeUser
{
    public class SubscribeUserCommandHandler : IRequestHandler<SubscribeUserCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SubscribeUserCommandHandler(IUserContext userContext, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userContext = userContext;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(SubscribeUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(_userContext.GetCrrentUserId);

            user.SubscribeTo(request.Type);

            _userRepository.Update(user);

            await _unitOfWork.SaveAsync();
        }
    }
}
