using Authorization.Api.Models.Requests;
using Authorization.Api.Services.Authentication.Request;
using Microsoft.AspNetCore.Identity;

namespace Authorization.Api.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationSignInResult> SignInUser(SignInUser user);
    }
}
