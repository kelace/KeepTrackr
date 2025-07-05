using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Executing.Domain.DeskAggregate;

namespace Executing.Domain.DeskAggregate
{
    public interface IDeskRepository
    {
        Task<Desk> Get(string name, Guid ownerId);
        Task AddAsync(Desk company);
        void Update(Desk company);
    }
}
