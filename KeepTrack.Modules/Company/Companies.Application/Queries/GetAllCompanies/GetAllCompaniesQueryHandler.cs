using Dapper;
using KeepTrack.Common;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Application.Queries.GetAllCompanies
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, List<CompanyDto>>
    {
        private readonly string _connectionString;
        private readonly IUserContext _userContext;
        public GetAllCompaniesQueryHandler(IOptions<ConnectionOptions> options, IUserContext userContext)
        {
            _connectionString = options.Value.DefaultConnection;
            _userContext = userContext;
        }
        public async Task<List<CompanyDto>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {

            var type = _userContext.GetWorkerType;

            var employeeSql = @" 
                            select c.CompanyName as Name, c.OwnerId from task.Companies c
                            join task.Executors_Company ec on c.CompanyName  = ec.Name and c.OwnerId = ec.OwnerId
                            where UserAssignedId = @Id";

            var employeerSql = "select * from companies.Company where OwnerId = @Id";

            var sql = type == WorkerType.Employer ? employeerSql : employeeSql;

            using(var connection = new SqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<CompanyDto>(sql, new { Id = _userContext.GetCrrentUserId});
                return result.ToList();
            }
        }
    }
}
