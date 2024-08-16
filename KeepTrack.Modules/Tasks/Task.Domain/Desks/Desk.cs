using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Boards;

namespace TaskManagment.Domain.Companies
{
    public class Desk : EntityBase, IAggregateRoot
    {
        public string CompanyName { get; private set; }
        public Guid OwnerId { get; private set; }

        public Column CreateBoard(string title, string companyName, Guid companyOwner, int order)
        {
            if (OwnerId != companyOwner && CompanyName != companyName) throw new Exception("asdasd");
            return Column.CreateBoard(title, companyName, companyOwner, order);
        }

        public static Desk CreateDesk(string name, Guid ownerId)
        {
            return new Desk
            {
                CompanyName = name,
                OwnerId = ownerId,
            };
        }
    }
}
