using ApplicationIdentity.Application.Commands.SignUpUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Commands.SignUpEmployee
{
    public class SignUpEmployeeCommand : IRequest<AuthenticationSignUpResult>
    {
        public Guid EmployeeId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}
