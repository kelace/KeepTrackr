using Employees.Application.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery : IRequest<List<EmployeeDTO>>
    {
    }
}
