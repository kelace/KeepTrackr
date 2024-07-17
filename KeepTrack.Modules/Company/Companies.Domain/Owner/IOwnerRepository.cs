using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Domain
{
    public interface IOwnerRepository
    {
        Task<Owner> Get(Guid id);
        Task Add(Owner owner);
        void Update(Owner owner);
    }
}
