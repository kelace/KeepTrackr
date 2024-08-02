using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain
{
    public class LabelLineItem : EntityBase
    {
        public Guid TaskId { get; private set; }
        public Guid LabelId { get; private set; }
    }
}
