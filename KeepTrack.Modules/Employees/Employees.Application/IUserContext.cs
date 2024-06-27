using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application
{
    public interface IUserContext
    {
        Guid GetCrrentUserId { get; }
    }
}
