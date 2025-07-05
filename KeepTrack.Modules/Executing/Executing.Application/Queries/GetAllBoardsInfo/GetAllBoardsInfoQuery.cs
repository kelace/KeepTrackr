using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Executing.Application.Queries.GetAllBoardsInfo.DTOs;

namespace Executing.Application.Queries.GetAllBoardsInfo
{
    public class GetAllBoardsInfoQuery : IRequest<BoardsDTO>
    {
        public string CompanyName { get; set; }
    }
}
