using Executing.Domain.CardAggregate;
using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executing.Application.Commands.AddCard
{
    public class AddCardCommand : IRequest<Result<Card, Error>>
    {
        public int Order { get; set; }
        public Guid BoardId { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
    }
}
