using Companies.Domain;
using Companies.Domain.Results;
using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Application.Commands.AddCompany
{
    public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommand, Result<Company, Error>>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IUserContext _userContext;
        private readonly IUnitOfWork _unitOfWork;
        public AddCompanyCommandHandler(IOwnerRepository ownerRepository, IUserContext userContext, IUnitOfWork unitOfWork)
        {
            _ownerRepository = ownerRepository;
            _userContext = userContext;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Company, Error>> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.Get(_userContext.GetCrrentUserId);

            var result = owner.AddCompany(request.Name);
            _ownerRepository.Update(owner);

            await _unitOfWork.SaveAsync();

            return result;
        }
    }
}
