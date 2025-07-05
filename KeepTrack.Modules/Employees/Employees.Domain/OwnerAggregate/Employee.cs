using Employees.Domain.RoleAggregate;
using KeepTrack.Common;


namespace Employees.Domain.OwnerAggregate
{
    public class Employee : EntityBase
    {
        public string Email { get; private set; }
        public string Name { get; private set; }
        public Guid RoleId { get; private set; }
        public List<PermissionId> AdditionalPermissions { get; private set; }
        public Guid CompanyId { get; private set; }
        public Guid OwnerId { get; private set; }

        public Employee(Guid id, string name, string email, Guid roleId, Guid companyId, Guid ownerId)
        {
            Id = id;
            Name = name;
            RoleId = roleId;
            CompanyId = companyId;
            OwnerId = ownerId;
            Email = email;
        }

        public bool CanAssignEmployeeToRole(List<Role> roles)
        {
            var role = roles.Where(x => x.Id == RoleId).First();

            if (role == Role.Administrator) return true;
            return false;
        }

        public bool CanAddNewUser(Role role)
        {
            if(role == Role.Administrator) return true;
            return false;
        }

        public bool DoesBelongToCompany(Guid companyId)
        {
            return companyId == CompanyId;
        }

        public void ChangeRole(Guid roleId)
        {
            RoleId = roleId;
        }

        public void MigrateToCompany(Guid companyId)
        {
            CompanyId = companyId;
        }
    }
}
