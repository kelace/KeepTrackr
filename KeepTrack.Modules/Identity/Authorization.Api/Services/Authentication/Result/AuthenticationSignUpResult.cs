using Microsoft.AspNetCore.Identity;

namespace Authorization.Api.Services.Authentication
{
    public class AuthenticationSignUpResult 
    {
        public bool Succeeded { get; set; }
        public string Token { get; set; }
        public WorkerType WorkerType { get; set; }
        public List<IdentityError> Errors { get; set; }
    }
}
