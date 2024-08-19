using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.Commands.UpdateCard
{
    public class UpdateCardCommand : IRequest
    {
        public Guid CardId { get; set; }
        public string? Name { get; set; }
        public DateTime? CompletionDate { get; set; }
        public Guid? AssignedUserId { get; set; }
    }
}
