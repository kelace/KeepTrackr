using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.Commands.ReorderCard
{
    public class ReorderCardCommand : IRequest
    {
        public Guid BoardId { get; set; }
        public Guid CardId { get; set; }
        public int SourceOrder { get; set; }
        public int DestinationOrder { get; set; }
        public string Company { get; set; }
    }
}
