using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain.Labels
{
    public class Label : EntityBase, IAggregateRoot
    {
        public string Name { get; private set; }

        public Label(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
