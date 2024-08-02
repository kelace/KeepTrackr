using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.Commands.UpdateBoard
{
    public class UpdateBoardCommand : IRequest, IApplicationCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
