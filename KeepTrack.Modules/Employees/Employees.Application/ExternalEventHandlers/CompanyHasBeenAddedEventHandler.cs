using Companies.Messages;
using Employees.Domain;
using Employees.Domain.Company;
using Employees.Domain.InvitingEmployee;
using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.ExternalEventHandlers
{
    public class CompanyHasBeenAddedEventHandler : INotificationHandler<CompanyHasBeenAddedExternalEvent>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CompanyHasBeenAddedEventHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CompanyHasBeenAddedExternalEvent notification, CancellationToken cancellationToken)
        {
            var company = Company.CreateCompany(notification.CompanyName);
            await _companyRepository.Add(company);
        }
    }
}
