using Employees.Domain.InvitingEmployee;
using Employees.Domain.InvitingEmployee.Result;
using Employees.Domain.OwnerAggregate;
using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Commands.InviteEmployee
{
    public class InviteEmployeeComand : IRequest<Result<Employee, KeepTrack.Common.Error>>, IApplicationCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid CompanyId { get; set; }
        //public List<string> Companies { get; set; }
        //public Guid CompanyId { get; set; }
    }
}
