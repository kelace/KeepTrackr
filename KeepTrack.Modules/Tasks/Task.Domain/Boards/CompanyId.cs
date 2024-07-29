using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain.Boards
{
    public class CompanyId
    {
        public string CompanyName { get; set; }
        public Guid CompanyOwnerId { get; set; }
    }
}
