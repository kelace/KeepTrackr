using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest
    {
        public Guid CardId { get; set; }
        public string TaskName { get; set; }
    }
}
