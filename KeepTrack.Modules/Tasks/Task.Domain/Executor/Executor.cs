using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain
{
    public class Executor : EntityBase, IAggregateRoot
    {
        public string Name { get; private set; }
        public ExecutorType Type { get; private set; }
        public DateTime Created { get; private set; }   

        public Result<Label, Error> CreateLabel(string name)
        {
            if (Type != ExecutorType.Employer) return Errors.EmployerLabelCreation;
            return new Label(name);
        }

        public static Executor Create(Guid id,string name, ExecutorType type)
        {
            return new Executor
            {
                Id = id,
                Created = DateTime.UtcNow,
                Name = name,
                Type = type
            };
        }
    }
}
