using Authorization.Entities;
using KeepTrack.Common;
using Microsoft.AspNetCore.Identity;

namespace ApplicationIdentity.Application.Commands.SignUpUser
{
    public class AuthenticationSignUpResult 
    {
        public bool Succeeded { get; set; }
        public string Token { get; set; }
        public WorkerType WorkerType { get; set; }
        public List<IdentityError> Errors { get; set; }
        public Guid UserId { get; set; }
    }
}
