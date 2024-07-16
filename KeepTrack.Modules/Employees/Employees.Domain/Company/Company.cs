using Employees.Domain.Base;
using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.Company
{
    public class Company : Entity, IAggregateRoot
    {
        public string CompanyName { get; set; }

        public static Company CreateCompany(string companyName)
        {
            return new Company { CompanyName = companyName };
        }
    }
}
