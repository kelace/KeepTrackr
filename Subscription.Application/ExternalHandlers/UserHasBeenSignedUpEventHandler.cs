using Authorization.Messages;
using MediatR;
using Subscription.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Application.ExternalHandlers
{
    public class UserHasBeenSignedUpEventHandler : INotificationHandler<UserHasBeenSignedUpMessage>
    {
        private readonly IUserRepository _userRepository;

        public UserHasBeenSignedUpEventHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UserHasBeenSignedUpMessage notification, CancellationToken cancellationToken)
        {
            var user = User.CreateUser(notification.UserId, notification.UserName);

            user.SubscribeToNormal();

            await _userRepository.AddAsync(user);
        }
    }
}
