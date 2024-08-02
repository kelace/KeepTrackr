using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain.Boards
{
    public interface IBoardRepository
    {
        Task<Board> Get(Guid id);
        Task<List<Board>> GetBoardsAsync(Guid ownerId, string companyName);
        void Update(Board board);
        void UpdateRange(List<Board> boards);
        System.Threading.Tasks.Task AddAsync(Board board);
    }
}
