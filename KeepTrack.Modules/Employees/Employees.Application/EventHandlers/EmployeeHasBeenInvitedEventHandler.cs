using Employees.Domain.InvitingEmployee.Events;
using Employees.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.EventHandlers
{
    public class EmployeeHasBeenInvitedEventhandler : INotificationHandler<EmployeeHasBeenInvitedEvent>
    {
        private readonly IMediator _mediator;
        public EmployeeHasBeenInvitedEventhandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Handle(EmployeeHasBeenInvitedEvent notification, CancellationToken cancellationToken)
        {
            var emailTemplate = @"

                Dear, <employeeName> You have been invited to <companyName> 
                please follow the link <a href='<link>'><link></a>;
    
            ";

            var email = emailTemplate.Replace("<employeeName>", notification.Name).Replace("<companyName>", notification.CompanyName);

            await _mediator.Publish(new EmployeeHasBeenInvitedInternalEvent
            {
                EmployeeEmail = notification.Email,
                Name = notification.Name,
                Email = email,
                EmployeeId = notification.EmployeeId,
                CompanyName = notification.CompanyName,
                MailId = notification.MailId,
            });

        }
    }
}
