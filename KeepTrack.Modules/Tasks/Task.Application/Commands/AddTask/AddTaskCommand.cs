using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.Commands.AddTask
{
    public class AddTaskCommand : IRequest, IApplicationCommand
    {
        public int Order { get; set; }
        public int Collumn { get; set; }
        public string CompanyName { get; set; }
    }
}
