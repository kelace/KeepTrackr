using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain.Boards
{
    public interface IColumnRepository
    {
        Task<Column> Get(Guid id);
        Task<List<Column>> GetBoardsAsync(Guid ownerId, string companyName);
        void Update(Column board);
        void UpdateRange(List<Column> boards);
        System.Threading.Tasks.Task AddAsync(Column board);
    }
}
