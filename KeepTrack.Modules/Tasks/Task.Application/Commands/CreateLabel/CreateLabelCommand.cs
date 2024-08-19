using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.Commands.CreateLabel
{
    public class CreateLabelCommand : IRequest
    {
        public string Color { get; set; }
        public string Title { get; set; }
        public Guid CardId { get; set; }
    }
}
