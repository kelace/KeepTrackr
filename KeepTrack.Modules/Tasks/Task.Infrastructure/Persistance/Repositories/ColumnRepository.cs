using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Boards;

namespace TaskManagment.Infrastructure.Persistance.Repositories
{
    public class ColumnRepository : IColumnRepository
    {
        private readonly TaskContext _context;

        public ColumnRepository(TaskContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task AddAsync(Column board)
        {
            await _context.AddAsync(board);
        }

        public async Task<Column> Get(Guid id)
        {
            return await _context.Boards.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Column>> GetBoardsAsync(Guid ownerId, string companyName)
        {
            return await _context.Boards.Where(x => x.CompanyId.CompanyName== companyName && x.CompanyId.CompanyOwnerId == ownerId).OrderBy(x => x.Order).ToListAsync();
        }

        public void Update(Column board)
        {
            _context.Update(board);
        }

        public void UpdateRange(List<Column> boards)
        {
            _context.UpdateRange(boards);
        }
    }
}
