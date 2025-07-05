using KeepTrack.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepTrackr.Context
{
    public class OwnerContext : IOwnerContext
    { 
        IHttpContextAccessor _httpContextAccessor;
        public OwnerContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid OwnerId => new Guid(_httpContextAccessor.HttpContext.User.Claims.Where(x => x.Value == "Owner").Select(x => x.Value).First());
    }
}
