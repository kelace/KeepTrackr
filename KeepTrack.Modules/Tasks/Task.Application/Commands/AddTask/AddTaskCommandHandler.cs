using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain;

namespace TaskManagment.Application.Commands.AddTask
{
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserContext _userContext;
        private readonly IUnitOfWork _unitOfWork;

        public AddTaskCommandHandler(ITaskRepository taskRepository, IUserContext userContext, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _userContext = userContext;
            _unitOfWork = unitOfWork;
        }

        public async System.Threading.Tasks.Task Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            //var companyId = new CompanyId
            //{
            //    CompanyName = request.CompanyName,
            //    CompanyOwnerId = _userContext.GetCrrentUserId
            //};

            //var task = Domain.Task.CreateEmpty(companyId);

            //await _taskRepository.AddAsync(task);
            //await _unitOfWork.SaveAsync();

        }
    }
}
