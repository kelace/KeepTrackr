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
        void Update(Board board);
        System.Threading.Tasks.Task AddAsync(Board board);
    }
}
