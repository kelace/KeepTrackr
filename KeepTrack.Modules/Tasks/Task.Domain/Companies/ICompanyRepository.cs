using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain.Companies
{
    public interface ICompanyRepository
    {
        Task<Company> Get(string name, Guid ownerId);
        System.Threading.Tasks.Task AddAsync(Company company);
        void Update(Company company);
    }
}
