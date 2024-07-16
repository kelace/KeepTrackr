using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.Company
{
    public interface ICompanyRepository
    {
        Task<Company> Get(string name);
        Task Add(Company company);
        void Update(Company company);
    }
}
