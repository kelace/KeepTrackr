using Employees.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Executing.Domain;
using Executing.Domain.Executors;

namespace Task.Application.ExternalEventHandlers
{
    public class EmployeeInvitedEventHandler : INotificationHandler<EmployeeHasBeenInvitedExternalEvent>
    {
        private readonly IExecutorRepository _executorRepository;

        public EmployeeInvitedEventHandler(IExecutorRepository executorRepository)
        {
            _executorRepository = executorRepository;
        }

        public async System.Threading.Tasks.Task Handle(EmployeeHasBeenInvitedExternalEvent notification, CancellationToken cancellationToken)
        {
            var executor = Executor.CreateEmployer(notification.EmployeeId, notification.Name, notification.CompanyOwner, notification.Companies);
            await _executorRepository.AddAsync(executor);
        }
    }
}
