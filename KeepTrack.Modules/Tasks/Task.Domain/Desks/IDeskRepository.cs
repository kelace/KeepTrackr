using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain.Companies
{
    public interface IDeskRepository
    {
        Task<Desk> Get(string name, Guid ownerId);
        System.Threading.Tasks.Task AddAsync(Desk company);
        void Update(Desk company);
    }
}
