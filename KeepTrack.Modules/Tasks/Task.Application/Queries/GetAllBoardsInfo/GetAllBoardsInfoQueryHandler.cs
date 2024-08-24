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
                            left join  ( select e.*, ec.OwnerId, ec.Name as Title  from task.Executors e join task.Executors_Company as ec on ec.OwnerId = @OwnerId and ec.Name = @CompanyName)  as e on e.Title = b.CompanyId_CompanyName and e.OwnerId =  b.CompanyId_CompanyOwnerId 
                            left join task.tasks as t on t.cardId = c.id
                            where b.CompanyId_CompanyName = @CompanyName and b.CompanyId_CompanyOwnerId = @OwnerId
                            order by [b].[ORDER] asc
                            ";

                BoardsDTO JoinMap(BoardDTO board, CardDTO card, LabelDTO label, UserDTO user, TaskDTO task)
                {
                  
                    var boards = new BoardsDTO();

                    boards.Boards.Add(board);

                    if (card is not null)
                    {
                        boards.Cards.Add(card);
                    }

                    if (label is not null)
                    {
                        boards.Labels.Add(label);
                    }

                    if (user is not null)
                    {
                        boards.Users.Add(user);
                    }

                    if (task is not null)
                    {
                        boards.Tasks.Add(task);
                    }

                    return boards;
                }

                var result = await connection.QueryAsync<BoardDTO, CardDTO, LabelDTO, UserDTO, TaskDTO, BoardsDTO >(sql, JoinMap, new { CompanyName = request.CompanyName, OwnerId = _userContext.GetCrrentUserId });

                var boards = result.SelectMany(x => x.Boards).GroupBy(x => x.Id).Select(x => x.First()).ToList();
                var cards = result.SelectMany(x => x.Cards).GroupBy(x => x.Id).Select(x => x.First()).ToList();
                var labels = result.SelectMany(x => x.Labels).GroupBy(x => x.Id).Select(x => x.First()).ToList();
                var users = result.SelectMany(x => x.Users).GroupBy(x => x.Id).Select(x => x.First()).ToList();
                var tasks = result.SelectMany(x => x.Tasks).GroupBy(x => x.Id).Select(x => x.First()).ToList();

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
                    Labels = labels,
                    Users = users,
                    Tasks = tasks
                };
            }
        }
    }
}
