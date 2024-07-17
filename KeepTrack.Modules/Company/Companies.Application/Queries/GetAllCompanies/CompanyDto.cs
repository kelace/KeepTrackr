using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Application.Queries.GetAllCompanies
{
    public class CompanyDto
    {
        public string Name { get; set; }
        public Guid OwnerId { get; set; }

    }
}
