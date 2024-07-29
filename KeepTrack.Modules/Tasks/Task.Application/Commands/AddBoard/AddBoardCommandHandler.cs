using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Boards;
using TaskManagment.Domain.Companies;
using TaskManagment.Domain.Executors;

namespace TaskManagment.Application.Commands.AddBoard
{
    public class AddBoardCommandHandler : IRequestHandler<AddBoardCommand>
    {
        private readonly IExecutorRepository _executorRepository;
        private readonly IBoardRepository _boardRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserContext _userContext;
        private readonly IUnitOfWork _unitOfWork;
        public AddBoardCommandHandler(IBoardRepository boardRepository, IUserContext userContext, IExecutorRepository executorRepository, IUnitOfWork unitOfWork, ICompanyRepository companyRepository)
        {
            _boardRepository = boardRepository;
            _userContext = userContext;
            _executorRepository = executorRepository;
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
        }

        public async System.Threading.Tasks.Task Handle(AddBoardCommand request, CancellationToken cancellationToken)
        {
            var executor = await _executorRepository.GetAsync(_userContext.GetCrrentUserId);
            var company = await _companyRepository.Get(request.CompanyName, executor.Id);

            var board = company.CreateBoard(request.Title, request.CompanyName, executor.Id, request.Order);

            await _boardRepository.AddAsync(board);
            await _unitOfWork.SaveAsync();
        }
    }
}
