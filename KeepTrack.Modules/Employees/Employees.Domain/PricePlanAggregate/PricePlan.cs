using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.PricePlanAggregate
{
    public class PricePlan : EntityBase
    {
        public PricePlanType Type { get; private set; }
        public int MaxCompanAllowed { get; private set; }
        public int MaxEmployeePerCompanAllowed { get; private set; }
    }
}
