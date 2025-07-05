using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.OwnerAggregate
{
    public interface IOwnerRepository
    {
        Task<Owner> GetAsync(Guid id);
        Task AddAsync(Owner owner);
        void Update(Owner owner);
        Task<Owner> GetById(Guid ownerId);
    }
}
