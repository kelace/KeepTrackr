using Employees.Domain.InvitingEmployee.Events;
using Employees.Domain.InvitingEmployee.Result;
using KeepTrack.Common;

namespace Employees.Domain.InvitingEmployee
{
    public class Owner : EntityBase, IAggregateRoot
    {
        //public bool IsAllowedToinvite { get; private set; }
        //public int AllowedEmployeeCountPerCompany { get; private set; }
        public List<Invitation> Invitations { get; private set; } 
        public List<Employee> Employees { get; private set; } 
        public List<Company> Companies { get; private set; } 

        public Result<InivtationResultInfo, Error> InviteNewEmployee(string email, string name, List<string>? companies)
        {
            if (IsEmployeeExist(name)) return new Error("", "");
            if (!IsOwnerFitInAllowedCompanyCount()) return new Error("", "");

            //var company = GetCompany(companyId);
            var empId = Guid.NewGuid();
            var employee = new Employee(empId) { Email = email, Name = name, OwnerId = Id, Companies = companies.Select(x => new CompanyItem { EmployeeId = empId, CompanyName = x, OwnerId = Id }).ToList() };
            var invitation = new Invitation(Guid.NewGuid()) { EmployeeId = employee.Id, MailId = Guid.NewGuid() };

            Employees.Add(employee);
            Invitations.Add(invitation);

            AddEvent(new EmployeeHasBeenInvitedEvent
            {
                EmployeeId = employee.Id,
                InvitationId = invitation.Id,
                Email = email,
                Name = name,
                Companies = employee.Companies.Select(x => (x.OwnerId, x.CompanyName)).ToList(),
                MailId = invitation.MailId,
                CompanyOwnerId = Id,
            });

            return new InivtationResultInfo
            {
                MailId = invitation.MailId,
                EmployeeId = employee.Id,
            };
        }

        public void AddCompany(string name)
        {
            Companies.Add(Company.CreateCompany(name));
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
        public static Owner CreateOwner(Guid id)
        {
            return new Owner
            {
                Id = id,
                Employees = new List<Employee>()
            };
        }
        public static Owner CreateOwner()
        {
            return new Owner
            {
                Id = Guid.NewGuid(),
                Employees = new List<Employee>()
            };
        }
    }
}
