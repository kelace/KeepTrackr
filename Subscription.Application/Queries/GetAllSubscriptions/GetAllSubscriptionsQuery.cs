using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Application.Queries.GetAllSubscriptions
{
    public class GetAllSubscriptionsQuery : IRequest<List<SubscriptionDTO>>
    {
    }
}
