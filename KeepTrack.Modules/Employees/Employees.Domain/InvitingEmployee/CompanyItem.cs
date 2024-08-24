using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.InvitingEmployee
{
    public class CompanyItem : EntityBase
    {
        public Guid EmployeeId { get; set; }
        public string CompanyName { get; set; }
        public Guid OwnerId { get; set; }

        //public CompanyItem(Guid id) 
        //{
        //    Id = id;
        //}
    }
}
