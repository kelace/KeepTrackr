using Authorization.Api.Services.Authentication.Request;
using Authorization.Entities;
using Authorization.Messages;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Authorization.Api.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IMediator _mediator;
        public AuthenticationService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager, IMediator mediator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _mediator = mediator;
        }

        public async Task<AuthenticationSignInResult> SignInUser(SignInUser user)
        {
            var existedUser = await _userManager.FindByNameAsync(user.Name);

            if (existedUser == null) return new AuthenticationSignInResult
            {
                Description = "User is not existed",
                UserNotExisted = true,
            };

            var signinResult = await _signInManager.CheckPasswordSignInAsync(existedUser, user.Password, lockoutOnFailure: false);

            if (!signinResult.Succeeded) return (AuthenticationSignInResult)signinResult;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f189f1nf0i13n09g13ngf013ngf01n01212sad321c3a"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("id", existedUser.Id.ToString()),
                new Claim("type", WorkerType.Employer.ToString()),
                new Claim("name", user.Name)
            };


            var d = DateTime.UtcNow.AddMinutes(15);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = credentials,
            };

            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var sectoken = handler.CreateToken(tokenDescriptor);
            var token = handler.WriteToken(sectoken);

            return new AuthenticationSignInResult(true, token)
            {
                Name = user.Name,
                WorkerType = WorkerType.Employer,
            };
        }
    }
}
