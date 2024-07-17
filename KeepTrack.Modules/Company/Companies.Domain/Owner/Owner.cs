using Companies.Domain.Events;
using Companies.Domain.Results;
using Companies.Domain.Results;
using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Domain
{
    public class Owner : EntityBase, IAggregateRoot
    {
        public List<Company> Companies { get; private set; }
        public Subscription Subscription { get; private set; }

        public Result<Company, Error> AddCompany(string name)
        {
            if (IsCompanyExist(name))  return new Error("Owner.CompanyExist", "Company is already exist");
            if (AreCompaniesCountLessThanAllowed()) return new Error("Owner.CompaniesCount", "Companies count has been reached maximum");

            var company = new Company(name, Id);
            Companies.Add(company);

            AddEvent(new CompanyHasBeenAddedEvent
            {
                OwnerId = Id,
                CompanyName = name
            });

            return company;
        }
        private bool AreCompaniesCountLessThanAllowed()
        {
            if(Companies.Count < Subscription.AllowedCompaniesCount) return false;
            return true;
        }
        private bool IsCompanyExist(string name)
        {
            return Companies.Any(x => x.Name == name);
        }

        public static Owner CreateOwner(Guid id, Subscription subscription)
        {
            return new Owner
            {
                Id = id,
                Subscription = subscription
            };
        }
    }
}
