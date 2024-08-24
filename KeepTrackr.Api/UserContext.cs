using Authorization.Entities;
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
        public WorkerType GetWorkerType
        {
            get
            {
                var userClaim = _httpContextAccessor.HttpContext.User.FindFirst("type");

                if (userClaim != null)
                {
                    return (WorkerType)Enum.Parse( typeof(WorkerType) ,userClaim.Value);
                }

                throw new NullReferenceException("User should be assigned to employer or employee role");
            }
        }
        public Guid GetCrrentUserId
        {
            get
            {
                var userClaim = _httpContextAccessor.HttpContext.User.FindFirst("id");
                var a = _httpContextAccessor.HttpContext.User.Claims.ToList();
                if (userClaim != null)
                {
                    return Guid.Parse(userClaim.Value);
                }

                return Guid.Empty;
            }
        }
    }
}
