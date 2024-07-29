using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.Queries.GetAllBoardsInfo.DTOs
{
    public class BoardDTO
    {
        public Guid Id { get; set; }
        public List<CardDTO> Cards { get; set; } = new List<CardDTO>();
        public string Title { get; set; }
    }
}
