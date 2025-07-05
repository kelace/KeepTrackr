using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executing.Domain.CardAggregate.Events
{
    public class UpdateCardEvent : INotification
    {
        public Guid CardId { get; set; }
        public Guid? ColumnId { get; set; }
        public string CardName { get; set; }
        public int Position { get; set; }
    }
}
