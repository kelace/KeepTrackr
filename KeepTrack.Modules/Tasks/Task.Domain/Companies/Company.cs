using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Boards;

namespace TaskManagment.Domain.Companies
{
    public class Company : EntityBase, IAggregateRoot
    {
        public string CompanyName { get; private set; }
        public Guid OwnerId { get; private set; }

        public Board CreateBoard(string title, string companyName, Guid companyOwner, int order)
        {
            if (OwnerId != companyOwner && CompanyName != companyName) throw new Exception("asdasd");
            return Board.CreateBoard(title, companyName, companyOwner, order);
        }

        public static Company CreateCompany(string name, Guid ownerId)
        {
            return new Company
            {
                CompanyName = name,
                OwnerId = ownerId,
            };
        }
    }
}
