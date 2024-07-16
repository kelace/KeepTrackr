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
            var sql = "select * from companies.Company where OwnerId = @Id";
            using(var connection = new SqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<CompanyDto>(sql, new { Id = _userContext.GetCrrentUserId});
                return result.ToList();
            }
        }
    }
}
