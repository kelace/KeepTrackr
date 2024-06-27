using Authorization.Api.Services.Authentication.Request;
using Authorization.Messages;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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

        public async Task<AuthenticationSignUpResult> EmployeeSignUp(SignUpEmployee model)
        {
            var user = await _userManager.FindByIdAsync(model.EmployeeId.ToString());
            var verificationResult = await _userManager.VerifyUserTokenAsync(user, TokenOptions.DefaultProvider, "SomeAnother", model.Token);
            //await _userManager.ValidatePasswordAsync(user, model.Password);
            _userManager.PasswordHasher.HashPassword(user, model.Password);
            //var refreshToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            if(!verificationResult) return new AuthenticationSignUpResult
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

            var passwordValidationResult = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValidationResult)
            {

                return new AuthenticationSignUpResult
                {
                    Errors = new List<IdentityError>
                    {
                        new IdentityError
                        {
                            Description = "Password is not correct"
                        }
                    },
                    Succeeded = false
                };
            }

            var hashedPassword = _userManager.PasswordHasher.HashPassword(user, model.Password);
            user.PasswordHash = hashedPassword;
            var result = await _userManager.UpdateAsync(user);
            return new AuthenticationSignUpResult
            {
                Errors = result.Errors.ToList(),
                Succeeded = result.Succeeded
            };
        }

        public async Task<AuthenticationSignUpResult> RegisterUser(SignUpUser userModel)
        {
            var user = new ApplicationUser
            {
                UserName = userModel.Name,
            };
            try
            {
                var r = WorkerType.Employer.ToString();
                var result = await _userManager.CreateAsync(user, userModel.Password);
     
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
                });

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f189f1nf0i13n09g13ngf013ngf01n01212sad321c3a"));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString() ),
                new Claim("type", WorkerType.Employer.ToString())
            };

                var Sectoken = new JwtSecurityToken(null,
                 null,
                 claims,
                 expires: DateTime.Now.AddMinutes(120),
                 signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                return new AuthenticationSignUpResult
                {
                    Errors = result.Errors.ToList(),
                    Token = token,
                    Succeeded = true,
                    WorkerType = WorkerType.Employer
                };
            }
            catch (Exception)
            {
                return new AuthenticationSignUpResult
                {
                    Errors = new List<IdentityError>()
                    {
                        new IdentityError
                        {
                            Description = "Something went wrong",
                            Code = "IntenarlError"
                        }
                    },
                    Succeeded = false
                };
                throw;
            }

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

            var Sectoken = new JwtSecurityToken(null,
             null,
             claims,
             expires: DateTime.Now.AddMinutes(120),
             signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return new AuthenticationSignInResult(true, token)
            {
                Name = user.Name,
                WorkerType = WorkerType.Employer,
            };
        }
    }
}
