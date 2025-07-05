using Employees.Domain.OwnerAggregate;
using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<Result<Company, Error>>
    {
        public string Name { get; set; }
    }
}
