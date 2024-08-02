using Employees.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain;
using TaskManagment.Domain.Executors;

namespace Task.Application.ExternalEventHandlers
{
    public class EmployeeInvitedEventHandler : INotificationHandler<EmployeeHasBeenInvitedInternalEvent>
    {
        private readonly IExecutorRepository _executorRepository;

        public EmployeeInvitedEventHandler(IExecutorRepository executorRepository)
        {
            _executorRepository = executorRepository;
        }

        public async System.Threading.Tasks.Task Handle(EmployeeHasBeenInvitedInternalEvent notification, CancellationToken cancellationToken)
        {
            var executor = Executor.Create(notification.EmployeeId, notification.Name, ExecutorType.Employee);
            await _executorRepository.AddAsync(executor);
        }
    }
}
