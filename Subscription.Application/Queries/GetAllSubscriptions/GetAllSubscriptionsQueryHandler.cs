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

namespace Subscription.Application.Queries.GetAllSubscriptions
{
    public class GetAllSubscriptionsQueryHandler : IRequestHandler<GetAllSubscriptionsQuery, List<SubscriptionDTO>>
    {
        private readonly string _connection;
        private readonly IUserContext _userContext;

        public GetAllSubscriptionsQueryHandler(IOptions<ConnectionOptions> connection, IUserContext userContext)
        {
            _connection = connection.Value.DefaultConnection;
            _userContext = userContext;
        }

        public async Task<List<SubscriptionDTO>> Handle(GetAllSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            using(var connection = new SqlConnection(_connection))
            {
                var sql = @"

                    select st.Type, case when si.Id is not null then 1 else 0 end  as IsSubscribed from dbo.SubscriptionTypes st
                    left join dbo.SubscriptionItem si on st.Type = si.Type and si.UserId = @UserId
                ";

                var result =  await connection.QueryAsync<SubscriptionDTO>(sql, new {UserId = _userContext.GetCrrentUserId});
                return result.ToList();
            }
        }
    }
}
