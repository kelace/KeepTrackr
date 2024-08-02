using Authorization.Entities;
using Authorization.Messages;
using KeepTrack.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationIdentity.Application.Commands.SignUpUser
{
    public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, AuthenticationSignUpResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public SignUpUserCommandHandler(UserManager<ApplicationUser> userManager, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthenticationSignUpResult> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.Name,
            };

            var r = WorkerType.Employer.ToString();
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded) return new AuthenticationSignUpResult
            {
                Errors = result.Errors.ToList(),
                Succeeded = false
            };

            var roleResult = await _userManager.AddToRoleAsync(user, r);

            if (!roleResult.Succeeded) return new AuthenticationSignUpResult
            {
                Errors = result.Errors.ToList(),
                Succeeded = false
            };

            await _mediator.Publish<UserHasBeenSignedUpMessage>(new UserHasBeenSignedUpMessage
            {
                UserId = user.Id,
                Name= request.Name,
            });

            await _unitOfWork.SaveAsync();

            return new AuthenticationSignUpResult
            {
                Succeeded = true,
                UserId = user.Id,
            };
        }
    }
}
