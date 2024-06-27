using Microsoft.AspNetCore.Identity;

namespace Authorization.Api.Services.Authentication
{
    public static class AllowedIdentityErrors
    {
        public static List<string> Errors = new List<string>()
        {
            nameof(IdentityErrorDescriber.DuplicateEmail),
        };
    }
}
