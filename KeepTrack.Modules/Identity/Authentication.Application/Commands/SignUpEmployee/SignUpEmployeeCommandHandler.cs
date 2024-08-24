using ApplicationIdentity.Application.Commands.SignUpUser;
using Authorization.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Authentication.Application.Commands.SignUpEmployee
{
    public class SignUpEmployeeCommandHandler : IRequestHandler<SignUpEmployeeCommand, AuthenticationSignUpResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public SignUpEmployeeCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<AuthenticationSignUpResult> Handle(SignUpEmployeeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.EmployeeId.ToString());

            var tokenDecoded = HttpUtility.UrlDecode(request.Token);

            var verificationResult = await _userManager.VerifyUserTokenAsync(user, TokenOptions.DefaultProvider, "InvitationUser", request.Token);

            _userManager.PasswordHasher.HashPassword(user, request.Password);

            if (!verificationResult) return new AuthenticationSignUpResult
            {
                Errors = new List<IdentityError>
                    {
                        new IdentityError
                        {
                            Description = "Token is invalid"
                        }
                    },
                Succeeded = false
            };

            //var passwordValidationResult = await _userManager.CheckPasswordAsync(user, request.Password);

            //if (!passwordValidationResult)
            //{

            //    return new AuthenticationSignUpResult
            //    {
            //        Errors = new List<IdentityError>
            //        {
            //            new IdentityError
            //            {
            //                Description = "Password is not correct"
            //            }
            //        },
            //        Succeeded = false
            //    };
            //}

            user.UserName = request.Name;
            user.Active = true;

            var hashedPassword = _userManager.PasswordHasher.HashPassword(user, request.Password);
            user.PasswordHash = hashedPassword;

            var result = await _userManager.UpdateAsync(user);

            return new AuthenticationSignUpResult
            {
                Errors = result.Errors.ToList(),
                Succeeded = result.Succeeded
            };
        }
    }
}
