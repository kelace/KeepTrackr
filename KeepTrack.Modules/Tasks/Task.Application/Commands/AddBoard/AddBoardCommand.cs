using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.Commands.AddBoard
{
    public class AddBoardCommand : IRequest, IApplicationCommand
    {
        public string Title { get; set; }
        public int Order { get; set; }
        public string CompanyName { get; set; }
    }
}
