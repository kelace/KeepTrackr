using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.AdministratorAggregate
{
    public class Administrator : EntityBase, IAggregateRoot
    {
        public AdministratorId Id { get; private set; }
        public bool CanAddAdministrators()
        {
            return false;
        }
    }
}
