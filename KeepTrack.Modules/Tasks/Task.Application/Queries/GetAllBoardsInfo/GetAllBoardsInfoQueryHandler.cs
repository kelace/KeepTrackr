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
    public class GetAllBoardsInfoQueryHandler : IRequestHandler<GetAllBoardsInfoQuery, BoardsDTO>
    {
        private readonly string _connection;
        private readonly IUserContext _userContext;
        public GetAllBoardsInfoQueryHandler(IOptions<ConnectionOptions> options, IUserContext userContext)
        {
            _connection = options.Value.DefaultConnection;
            _userContext = userContext;
        }
        public async Task<BoardsDTO> Handle(GetAllBoardsInfoQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_connection))
            {
                var sql = @"
                            
                            select * from task.Boards b
                            left join ( select *, row_number() OVER (ORDER BY ci.[order]) as no from task.Cards as ci) as c on b.Id = c.BoardId                              
                            left join task.label as l on c.Id = l.CardId                              
                            where b.CompanyId_CompanyName = @CompanyName and b.CompanyId_CompanyOwnerId = @OwnerId
                            order by [b].[ORDER] asc
                            ";

                BoardsDTO JoinMap(BoardDTO board, CardDTO card, LabelDTO label)
                {
                  
                    var boards = new BoardsDTO();

                    boards.Boards.Add(board);

                    if (card is null) return boards;

                    boards.Cards.Add(card);

                    if (label is null) return boards;

                    boards.Labels.Add(label);

                    return boards;
                }

                var result = await connection.QueryAsync<BoardDTO, CardDTO, LabelDTO, BoardsDTO>(sql, JoinMap, new { CompanyName = request.CompanyName, OwnerId = _userContext.GetCrrentUserId });

                var boards = result.SelectMany(x => x.Boards).GroupBy(x => x.Id).Select(x => x.First()).ToList();
                var cards = result.SelectMany(x => x.Cards).GroupBy(x => x.Id).Select(x => x.First()).ToList();
                var labels = result.SelectMany(x => x.Labels).GroupBy(x => x.Id).Select(x => x.First()).ToList();


                //return boards.GroupBy(x => new {x.Boards, x.Cards}).Select(b =>
                //{
                //    var board = b.First();
                //    board.Cards = b.SelectMany(x => x.Cards).ToList();
                //    return board;
                //}).ToList();

                return new BoardsDTO
                {
                    Boards = boards,
                    Cards = cards,
                    Labels = labels
                };
            }
        }
    }
}
