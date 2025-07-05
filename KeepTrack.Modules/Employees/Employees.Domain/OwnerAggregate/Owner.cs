using Employees.Domain.AdministratorAggregate;
using Employees.Domain.ManagerAggregate;
using Employees.Domain.OwnerAggregate.Events;
using Employees.Domain.OwnerAggregate.Events.CompanyEvents;
using Employees.Domain.OwnerAggregate.Events.EmployeeEvents;
using Employees.Domain.PricePlanAggregate;
using Employees.Domain.RoleAggregate;
using Employees.Domain.SubscriptionAggregate;
using KeepTrack.Common;

namespace Employees.Domain.OwnerAggregate
{
    public class Owner : EntityBase, IAggregateRoot
    {
        //public bool IsAllowedToinvite { get; private set; }
        //public int AllowedEmployeeCountPerCompany { get; private set; }
        //public List<Invitation> Invitations { get; private set; } 
        //public List<Employee> Employees { get; private set; } 
        public Guid SubscriptionId { get; private set; }
        //public List<ManagerId> Managers { get; private set; }
        //public List<AdministratorId> Administrators { get; private set; }
        public List<Company> Companies { get; private set; }
        public List<Employee> Employees { get; private set; }   

        public Result<Employee, Error> ModifyEmployee(Guid employeeId, Guid companyId, Guid roleId, Guid managerId, List<Role> roles)
        {
            var employee = Employees.Where(x => x.Id == employeeId).FirstOrDefault();
            var manager = Employees.Where(x => x.Id == managerId).FirstOrDefault();

            if (!employee.DoesBelongToCompany(companyId)) return new Error("", "");

            var newEmployeeRole = roles.First(x => x.Id == roleId);

            if (!manager.CanAssignEmployeeToRole(roles) && newEmployeeRole.IsNotOwner) return new Error("", "");

            employee.MigrateToCompany(companyId);
            employee.ChangeRole(roleId);

            AddEvent(new EmployeeModifiedEvent
            {
                RoleId = roleId,
                CompanyId = companyId,
            });

            return employee;
        }

        public Result<Guid, Error> RemoveCompany(Guid id)
        {
            var company = GetCompanyById(id);
            Companies.Remove(company);

            return id;
        }
        public Result<Company, Error> RegisterCompany(string name, PricePlan plan, Subscription subscription)
        {

            if (Companies.Count >= plan.MaxCompanAllowed)
            {
                return new Error("", "");
            }

            if (Companies.Where(x => x.CompanyName == name).Any())
            {
                return new Error("", "");
            }

            var company = new Company(Guid.NewGuid(), name);

            Companies.Add(company);

            AddEvent(new CompanyCreatedEvent
            {
                Id = company.Id,
                Name = company.CompanyName
            });

            return company;
        }

        public Result<Company, Error> RegisterCompanyByManagerInitiative(string name, Guid managerId, PricePlan plan, Subscription subscription, Role role)
        {
            if (Companies.Count >= plan.MaxCompanAllowed)
            {
                return new Error("", "");
            }

            if (Companies.Where(x => x.CompanyName == name).Any())
            {
                return new Error("", "");
            }

            var manager = Employees.FirstOrDefault(x => x.Id == managerId);

            if (!manager.CanAddNewUser(role)) return new Error("", "");

            var company = new Company(Guid.NewGuid(), name);

            Companies.Add(company);

            AddEvent(new CompanyCreatedEvent
            {
                Id = company.Id,
                Name = company.CompanyName
            });

            return company;
        }

        public Result<Company, Error> ModifyCompany(Guid id, string name)
        {
            if (IsCompanyWithNameExist(name)) return new Error("", "");

            var company = GetCompanyById(id);

            company.ChangeName(name);

            AddEvent(new CompanyChangedNameEvent
            {
                Name = name,
            });

            return company;
        }

        public Result<Employee, Error> InviteNewEmployee(string email, string name, Guid companyId, PricePlan plan, Subscription subscription, Role defautlEmployeeRole)
        {
            if (IsEmployeeExist(email)) return new Error("", "");
            if (!IsOwnerFitInAllowedCompanyCount()) return new Error("", "");
            //if (IsCompanyExist(name)) return new Error("Owner.CompanyExist", "Company is already exist");
            //if (AreCompaniesCountLessThanAllowed()) return new Error("Owner.CompaniesCount", "Companies count has been reached maximum");

            var company = GetCompanyById(companyId);

            if(company.Employees.Count() >= plan.MaxEmployeePerCompanAllowed) return new Error("", "");

            //var company = GetCompany(companyId);
            var empId = Guid.NewGuid();
            var employee = new Employee(Guid.NewGuid(), name, email, defautlEmployeeRole.Id, companyId, Id);
            //var invitation = new Invitation(Guid.NewGuid()) { EmployeeId = employee.Id, MailId = Guid.NewGuid() };

            Employees.Add(employee);
            //Invitations.Add(invitation);

            AddEvent(new EmployeeHasBeenInvitedEvent
            {
                EmployeeId = employee.Id,
                //InvitationId = invitation.Id,
                Email = email,
                Name = name,
                //Companies = employee.Companies.Select(x => (x.OwnerId, x.CompanyName)).ToList(),
                //MailId = invitation.MailId,
                OwnerId = Id,
            });

            return employee;
        }

        private void AssignEmployeeToAnotherCompany(Employee employee, Guid companyId)
        {
            employee.MigrateToCompany(companyId);
        }

        private bool IsCompanyWithNameExist(string name)
        {
            return Companies.Where(x => x.CompanyName == name).Any();
        }

        private Company GetCompanyById(Guid id)
        {
            return Companies.Where(x => x.Id == id).First();
        }

        private bool IsOwnerFitInAllowedCompanyCount()
        {
            return true;
        }
        private bool IsEmployeeExist(string name)
        {
            return Employees.Any(x => x.Email == name);
        }
        public static Owner CreateOwner(Guid id)
        {
            return new Owner
            {
                Id = id,
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
