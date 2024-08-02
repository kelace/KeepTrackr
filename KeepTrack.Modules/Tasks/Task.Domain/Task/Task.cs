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
        public List<LabelLineItem> Labels { get; private set; }

        public void AssignExecutorToTask(Guid id)
        {
            AssignedTo = id;
        }

        public void AddLabel(LabelLineItem item)
        {
            if (Labels.Count > 10) throw new Exception("asdasd");
            Labels.Add(item);
        }

        //public static Task CreateEmpty(CompanyId companyId)
        //{
        //    return new Task
        //    {
        //        CompanyId = companyId,
        //        Created = DateTime.Now,
        //        Updated = DateTime.Now
        //    };

        //}

    }
}
