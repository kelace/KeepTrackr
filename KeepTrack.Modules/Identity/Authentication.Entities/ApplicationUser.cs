using Microsoft.AspNetCore.Identity;

namespace Authorization.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public bool Active { get; set; }
    }
}
