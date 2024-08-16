using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.Queries.GetAllBoardsInfo.DTOs
{
    public class BoardsDTO
    {
        public List<BoardDTO> Boards { get; set; } = new List<BoardDTO>();
        public List<CardDTO> Cards { get; set; } = new List<CardDTO>();
        public List<LabelDTO> Labels { get; set; } = new List<LabelDTO>();
    }
}
