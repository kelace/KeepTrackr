using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationIdentity.Application.Commands.SignUpUser
{
    public class SignUpUserCommand : IRequest<AuthenticationSignUpResult>, IApplicationCommand
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
