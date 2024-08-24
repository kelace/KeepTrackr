using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Boards;
using TaskManagment.Domain.Cards;

namespace TaskManagment.Domain.Executors
{
    public class Executor : EntityBase, IAggregateRoot
    {
        public string Name { get; private set; }
        public ExecutorType ExecutorType { get; private set; }
        public DateTime Created { get; private set; }   

        public List<Company> Companies { get; private set; }

        public Result<Label, Error> CreateLabel(string name, string color, Guid cardId)
        {
            if (ExecutorType != ExecutorType.Employer) return Errors.EmployerLabelCreation;
            return new Label(name, color, cardId);
        }

        public static Executor CreateEmployer(Guid id, string name, Guid ownerId, List<(Guid ownerId, string name)> companies )
        {

            var comps = companies.Select(x => new Company(x.name, x.ownerId, id)).ToList();

            return new Executor
            {
                Id = id,
                Created = DateTime.UtcNow,
                Name = name,
                ExecutorType = ExecutorType.Employer,
                Companies = comps
            };
        }

        public static Executor CreateEmployee(Guid id, string name, Guid companyOwnerId, string companyName)
        {
            return new Executor
            {
                Id = id,
                Created = DateTime.UtcNow,
                Name = name,
                ExecutorType = ExecutorType.Employee,
            };
        }

        public static Executor Create(Guid id,string name, ExecutorType type)
        {
            return new Executor
            {
                Id = id,
                Created = DateTime.UtcNow,
                Name = name,
                ExecutorType = type
            };
        }
    }
}
