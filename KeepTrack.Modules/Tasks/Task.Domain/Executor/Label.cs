using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain
{
    public class Label
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Label(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
