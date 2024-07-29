using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Boards;

namespace TaskManagment.Infrastructure.Persistance.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly TaskContext _context;

        public BoardRepository(TaskContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task AddAsync(Board board)
        {
            await _context.AddAsync(board);
        }

        public async Task<Board> Get(Guid id)
        {
            return await _context.Boards.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Update(Board board)
        {
            _context.Update(board);
        }
    }
}
