using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.PricePlanAggregate
{
    public interface IPricePlanRepository
    {
        public Task<PricePlan> GetById(Guid id);
    }
}
