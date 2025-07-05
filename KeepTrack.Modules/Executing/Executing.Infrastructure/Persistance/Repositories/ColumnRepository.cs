using Executing.Domain.ColumnAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executing.Infrastructure.Persistance.Repositories
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
            return await _context.Columns.Where(x => x.Id.Value == id).FirstOrDefaultAsync();
        }

        public async Task<List<Column>> GetBoardsAsync(Guid ownerId, Guid deskId)
        {
            //return await _context.Columns.Where(x => x.DeskID == deskId && x.CompanyId.CompanyOwnerId == ownerId).OrderBy(x => x.Order).ToListAsync();
            return await _context.Columns.Where(x => x.DeskID == deskId ).OrderBy(x => x.Order).ToListAsync();
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
