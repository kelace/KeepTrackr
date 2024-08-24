using MediatR;

namespace Employees.Messages
{
    public class EmployeeHasBeenInvitedInternalEvent : INotification
    {
        public Guid EmployeeId { get; set; }
        public Guid InvitationId { get; set; }
        public Guid MailId { get; set; }
        public string EmployeeEmail { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public List<(Guid employeeId, string companyName)> Companies { get; set; }
        public Guid CompanyOwner { get; set; }
    }
}
