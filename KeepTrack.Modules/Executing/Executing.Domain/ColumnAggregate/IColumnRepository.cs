using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executing.Domain.ColumnAggregate
{
    public interface IColumnRepository
    {
        Task<Column> Get(Guid id);
        Task<List<Column>> GetBoardsAsync(Guid ownerId, Guid deskId);
        void Update(Column board);
        void UpdateRange(List<Column> boards);
        System.Threading.Tasks.Task AddAsync(Column board);
    }
}
