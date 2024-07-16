using KeepTrack.Common;

namespace Employees.Infrastructure
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Guid GetCrrentUserId
        {
            get
            {
                var userClaim = _httpContextAccessor.HttpContext.User.FindFirst("id");
                if (userClaim != null)
                {
                    return Guid.Parse(userClaim.Value);
                }

                return Guid.Empty;
            }
        }
    }
}
