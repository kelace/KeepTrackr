using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.ManagerAggregate
{
    public interface IManagerRepository
    {
        Task<Manager> GetCurrent();
    }
}
