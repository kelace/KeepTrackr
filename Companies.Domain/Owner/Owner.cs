using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Domain
{
    public class Owner
    {
        public Guid Id { get; private set; }
        public List<Company> Companies { get; private set; }
        public Subscription Subscription { get; private set; }

        public void AddCompany(string name)
        {
            if (IsCompanyExist(name)) throw new Exception();
            if (AreCompaniesCountLessThanAllowed()) throw new Exception();

            Companies.Add(new Company(name, Id));
        }
        private bool AreCompaniesCountLessThanAllowed()
        {
            if(Companies.Count > Subscription.AllowedCompaniesCount) return false;
            return true;
        }
        private bool IsCompanyExist(string name)
        {
            return Companies.Any(x => x.Name == name);
        }
    }
}
