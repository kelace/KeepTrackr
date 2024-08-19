using Employees.Domain.Base;
using Employees.Domain.InvitingEmployee.Events;
using Employees.Domain.InvitingEmployee.Result;
using KeepTrack.Common;

namespace Employees.Domain.InvitingEmployee
{
    public class Owner : AggregateRoot, IAggregateRoot
    {
        //public bool IsAllowedToinvite { get; private set; }
        //public int AllowedEmployeeCountPerCompany { get; private set; }
        public List<Invitation> Invitations { get; private set; } = new List<Invitation>();
        public List<Employee> Employees { get; private set; } = new List<Employee>();
        //public List<Company> Companies { get; private set; } = new List<Company>();

        public Owner(Guid id) : base(id) 
        {

        }
        public Result<InivtationResultInfo, Error> InviteNewEmployee(string email, string name)
        {
            if (IsEmployeeExist(name)) return new Error("", "");
            if (!IsOwnerFitInAllowedCompanyCount()) return new Error("", "");

            //var company = GetCompany(companyId);
            var employee = new Employee(Guid.NewGuid()) { Email = email, Name = name, OwnerId = Id };
            var invitation = new Invitation { EmployeeId = employee.Id, MailId = Guid.NewGuid() };

            this.Employees.Add(employee);
            Invitations.Add(invitation);

            AddEvent(new EmployeeHasBeenInvitedEvent
            {
                EmployeeId = employee.Id,
                InvitationId = invitation.Id,
                Email = email,
                Name = name,
                CompanyName = "company",
                MailId = invitation.MailId,
                CompanyOwnerId = Id,
            });

            return new InivtationResultInfo
            {
                MailId = invitation.MailId
            };
        }

        //private Company GetCompany(Guid companyId)
        //{
        //    return Companies.FirstOrDefault(x => x.Id == companyId);
        //}

        private bool IsOwnerFitInAllowedCompanyCount()
        {
            return true;
        }
        private bool IsEmployeeExist(string name)
        {
            return Employees.Any(x => x.Name == name);
        }

        public static Owner CreateOwner()
        {
            return new Owner(Guid.NewGuid())
            {
                Employees = new List<Employee>()
            };
        }
    }
}
