using ApplicationIdentity.Application.Commands.SignUpUser;
using Authentication.Application.Commands.SignUpEmployee;
using Authorization.Api.Models.Requests;
using Authorization.Api.Services.Authentication;
using Authorization.Api.Services.Authentication.Request;
using Authorization.Entities;
using KeepTrack.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authorization.Api.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class AuthorizationController : ControllerBase
	{
		private readonly IAuthenticationService _authenticationService;
		private readonly IMediator _mediator;
		public AuthorizationController(IAuthenticationService authenticationService, IMediator mediator)
		{
			_authenticationService = authenticationService;
            _mediator = mediator;
        }

		[HttpPost]
		[Route("signup")]
		public async Task<AuthenticationSignUpResult> SignUp(SignUpUser user)
		{
            var result = await _mediator.Send<AuthenticationSignUpResult>(new SignUpUserCommand
            {
                Name = user.Name,
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword,
            });

            if (!result.Succeeded) return result;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f189f1nf0i13n09g13ngf013ngf01n01212sad321c3a"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("id", result.UserId.ToString() ),
                new Claim("type", WorkerType.Employer.ToString())
            };

            var Sectoken = new JwtSecurityToken(null,
             null,
             claims,
             expires: DateTime.Now.AddMinutes(120),
             signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            result.WorkerType = WorkerType.Employer;
            result.Token = token;

            return result;
        }

        [HttpPost]
        [Route("signin")]
        public async Task<AuthenticationSignInResult> SignIn(SignInUser user)
        {
            return  await _authenticationService.SignInUser(user);
        }

        [HttpPut]
        [Route("invitation/signup")]
        public async Task<AuthenticationSignUpResult> InvitationSignup(SignUpEmployee employee)
        {
            return await _mediator.Send<AuthenticationSignUpResult>(new SignUpEmployeeCommand
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Password = employee.Password,
                ConfirmPassword = employee.ConfirmPassword,
                Token = employee.Token,
            });
        }
    }
}
