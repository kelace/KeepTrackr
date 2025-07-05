using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executing.Domain
{
    public class Job : EntityBase, IAggregateRoot
    {
        public string Name { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Updated { get; private set; }
        public Guid CardId { get; private set; }
        public bool Completed { get; private set; }


        public Job(string name, Guid cardId)
        {
            Name = name;
            CardId = cardId;
        }

        //public void AssignExecutorToTask(Guid id)
        //{
        //    AssignedTo = id;
        //}

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
