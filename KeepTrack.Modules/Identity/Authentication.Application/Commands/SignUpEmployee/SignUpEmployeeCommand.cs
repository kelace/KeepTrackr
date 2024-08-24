using ApplicationIdentity.Application.Commands.SignUpUser;
using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Commands.SignUpEmployee
{
    public class SignUpEmployeeCommand : IRequest<AuthenticationSignUpResult>, IApplicationCommand
    {
        public Guid EmployeeId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
    }
}
