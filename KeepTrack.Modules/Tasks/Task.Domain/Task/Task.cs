using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain
{
    public class Task : EntityBase, IAggregateRoot
    {
        public string Name { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Updated { get; private set; }
        public Guid AssignedTo { get;  private set; }
        public List<Guid> Labels { get; private set; }
        public CompanyId CompanyId { get; private set; }

        public void AssignExecutorToTask(Guid id)
        {
            AssignedTo = id;
        }

        public void AddLabel(Guid id)
        {
            Labels.Add(id);
        }

        public static Task CreateEmpty(CompanyId companyId)
        {
            return new Task
            {
                CompanyId = companyId,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };

        }

    }
}
