using Companies.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Companies;

namespace TaskManagment.Application.ExternalEventHandlers
{
    public class CompanyCreatedEventHandler : INotificationHandler<CompanyHasBeenAddedExternalEvent>
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyCreatedEventHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async System.Threading.Tasks.Task Handle(CompanyHasBeenAddedExternalEvent notification, CancellationToken cancellationToken)
        {
            await _companyRepository.AddAsync(Company.CreateCompany(notification.CompanyName, notification.OwnerId));
        }
    }
}
