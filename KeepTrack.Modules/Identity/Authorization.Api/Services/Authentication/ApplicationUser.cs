using Microsoft.AspNetCore.Identity;

namespace Authorization.Api.Services.Authentication
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public bool Active { get; set; }
    }
}
