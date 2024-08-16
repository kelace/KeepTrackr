using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.Queries.GetAllBoardsInfo.DTOs
{
    public class LabelDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
