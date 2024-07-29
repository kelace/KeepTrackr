using Dapper;
using KeepTrack.Common;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Application.Queries.GetAllBoardsInfo.DTOs;

namespace TaskManagment.Application.Queries.GetAllBoardsInfo
{
    public class GetAllBoardsInfoQueryHandler : IRequestHandler<GetAllBoardsInfoQuery, List<BoardDTO>>
    {
        private readonly string _connection;
        private readonly IUserContext _userContext;
        public GetAllBoardsInfoQueryHandler(IOptions<ConnectionOptions> options, IUserContext userContext)
        {
            _connection = options.Value.DefaultConnection;
            _userContext = userContext;
        }
        public async Task<List<BoardDTO>> Handle(GetAllBoardsInfoQuery request, CancellationToken cancellationToken)
        {
            using(var connection = new SqlConnection(_connection))
            {
                var sql = @"
                            
                            select * from task.Boards b
                            left join task.Cards c on b.Id = c.BoardId                            
                            where b.CompanyId_CompanyName = @CompanyName and b.CompanyId_CompanyOwnerId = @OwnerId

                            ";

                BoardDTO JoinMap(BoardDTO board, CardDTO card)
                {
                    if (card is null) return board;

                    board.Cards.Add(card);
                    return board;
                }

                var boards = await connection.QueryAsync<BoardDTO, CardDTO, BoardDTO>(sql, JoinMap, new {CompanyName = request.CompanyName, OwnerId = _userContext.GetCrrentUserId });
               
                return boards.GroupBy(x => x.Id).Select(b =>
                {
                    var board = b.First();
                    board.Cards = b.SelectMany(x => x.Cards).ToList();
                    return board;
                }).ToList();
            }
        }
    }
}
