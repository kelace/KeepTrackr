using Authorization.Messages;
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
    public class EmployerSignedUpEventHandler : INotificationHandler<UserHasBeenSignedUpMessage>
    {
        private readonly IExecutorRepository _executorRepository;

        public EmployerSignedUpEventHandler(IExecutorRepository executorRepository)
        {
            _executorRepository = executorRepository;
        }
        public async System.Threading.Tasks.Task Handle(UserHasBeenSignedUpMessage notification, CancellationToken cancellationToken)
        {
            var executor = Executor.Create(notification.UserId, notification.Name, ExecutorType.Employer);
            await _executorRepository.AddAsync(executor);
        }
    }
}
