using Authorization.Api.Models.Requests;
using Authorization.Api.Services.Authentication;
using Authorization.Api.Services.Authentication.Request;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Api.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class AuthorizationController : ControllerBase
	{
		private readonly IAuthenticationService _authenticationService;
		public AuthorizationController(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
        }

		[HttpPost]
		[Route("signup")]
		public async Task<AuthenticationSignUpResult> SignUp(SignUpUser user)
		{
			return await _authenticationService.RegisterUser(user);
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
            return await _authenticationService.EmployeeSignUp(employee);
        }
    }
}
