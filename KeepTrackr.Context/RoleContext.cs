using KeepTrack.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepTrackr.Context
{
    public class RoleContext : IRoleContext
    {
        IHttpContextAccessor _httpContextAccessor;
        public RoleContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetUserRole => _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Value == "Role").Select(x => x.Value).First();
    }
}
