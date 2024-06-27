using Authorization.Api.Models;
using Authorization.Api.Services.Authentication;
using Authtorization.Persistance;
using Employees.Messages;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Authorization.Api.InternalHandlers
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
            //var link = _linkGenerator.GetUriByAction(_httpContextAccessor.HttpContext, action: "InvitationSignUp", controller: "Authorization", values: new {id = notification.EmployeeId, token = invitationToken });
            var link = $"/authentication/invitation/signup?token={invitationToken};user={notification.EmployeeId}";

            var mailValue = notification.Email.Replace("<link>", link);

            var mail = new Mail
            {
                Id = notification.MailId,
                Value = mailValue
            };

            await _context.Mails.AddAsync(mail);
            await _context.SaveChangesAsync();
        }
    }
}
