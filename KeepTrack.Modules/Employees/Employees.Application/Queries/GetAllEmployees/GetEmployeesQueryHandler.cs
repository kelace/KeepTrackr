using Dapper;
using Employees.Application.Queries.DTOs;
using MediatR;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Queries.GetAllEmployees
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDTO>>
    {
        private readonly IUserContext _userContext;
        public GetEmployeesQueryHandler(IUserContext userContext)
        {
            _userContext = userContext;
        }
        public async Task<List<EmployeeDTO>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            using(var connection = new SqlConnection("Server=DESKTOP-6JEENNA;Database=KeepTrackrDB;User Id=sa;Password=sa;TrustServerCertificate=True"))
            {
                var ownerId = _userContext.GetCrrentUserId;
                var sql = $"select Id, Name from emp.Employees where OwnerId = @OwnerId";

                var employees = await connection.QueryAsync<EmployeeDTO>(sql, new {OwnerId = ownerId});

                return employees?.ToList();
            }
        }
    }
}
