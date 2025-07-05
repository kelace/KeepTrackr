using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executing.Application.Queries.GetAllBoardsInfo.DTOs
{
    public class CardDTO
    {
        public Guid Id { get; set; }
        public Guid BoardId { get; set; }
        public string Title { get; set; }
        public DateTime CompletionDate { get; set; }
        public int Order { get; set; }
    }
}
