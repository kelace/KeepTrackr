using Authorization.Entities;
using Authorization.Infastructure;
using Employees.Messages;
using KeepTrack.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Authentication.Application.ExternalEventHandlers
{
    public class EmployeeHasBeenInvitedHandler : INotificationHandler<EmployeeHasBeenInvitedInternalEvent>
    {
        private readonly AuthContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly LinkGenerator _linkGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmployeeHasBeenInvitedHandler(AuthContext context, LinkGenerator linkGenerator, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _linkGenerator = linkGenerator;
            _userManager = userManager;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task Handle(EmployeeHasBeenInvitedInternalEvent notification, CancellationToken cancellationToken)
        {

            var newUser = new ApplicationUser
            {
                Id = notification.EmployeeId,
                UserName = notification.Name,
                Email = notification.EmployeeEmail,
                Active = false
            };

            await _userManager.CreateAsync(newUser);
            await _userManager.AddToRoleAsync(newUser, WorkerType.Employee.ToString());

            var invitationToken = await _userManager.GenerateUserTokenAsync(newUser, TokenOptions.DefaultProvider, "InvitationUser");
            var tokenEncoded = HttpUtility.UrlEncode(invitationToken);
            var link =  $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/authentication/invitation/signup?token={tokenEncoded}&user={notification.EmployeeId}";

            var mailValue = notification.Email.Replace("<link>", link);

            var mail = new Mail
            {
                Id = notification.MailId,
                Value = mailValue
            };

            await _context.Mails.AddAsync(mail);
        }
    }
    
}
