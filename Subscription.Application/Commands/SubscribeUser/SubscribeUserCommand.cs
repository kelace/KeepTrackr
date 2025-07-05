using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionAndPlan.Application.Commands.SubscribeUser
{
    public class SubscribeUserCommand : IRequest
    {
        public Guid PlanId { get; set; }
    }
}
