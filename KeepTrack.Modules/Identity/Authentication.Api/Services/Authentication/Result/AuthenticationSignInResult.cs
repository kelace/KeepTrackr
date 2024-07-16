using Authorization.Entities;
using Microsoft.AspNetCore.Identity;

namespace Authorization.Api.Services.Authentication
{
    public class AuthenticationSignInResult : SignInResult
    {
        public AuthenticationSignInResult(bool succees, string token)
        {
            Succeeded = succees;
            Token = token;
        }
        public AuthenticationSignInResult()
        {

        }
        public bool UserNotExisted { get; set; }
        public string Description { get; set; }
        public string Token { get; private set; }
        public WorkerType WorkerType { get; set; }
        public string Name { get; set; }
    }
}
