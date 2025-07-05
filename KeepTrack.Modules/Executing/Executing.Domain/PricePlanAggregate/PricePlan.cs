using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executing.Domain.PricePlanAggregate
{
    public class PricePlan : EntityBase, IAggregateRoot
    {
        public int MaxCollumnAllowed { get; set; }
    }
}
