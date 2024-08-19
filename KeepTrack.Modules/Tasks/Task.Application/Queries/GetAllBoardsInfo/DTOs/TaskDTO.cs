using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.Queries.GetAllBoardsInfo.DTOs
{
    public class TaskDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
