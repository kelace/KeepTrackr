using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Executing.Domain.PricePlanAggregate;
using Executing.Domain.SubscriptionAggregate;
using Executing.Domain.UserAggregate;
using Executing.Domain.ColumnAggregate;

namespace Executing.Domain.DeskAggregate
{
    public class Desk : EntityBase, IAggregateRoot
    {
        public string CompanyName { get; private set; }
        public Guid OwnerId { get; private set; }
        public List<UserId> Users { get; private set; }
        //public List<User> Users { get; private set; }
        public List<ColumnId> Columns { get; private set; }
        //public List<CardId> Cards { get; private set; }
        public Guid SubscriptionId { get; private set; }

        public Result<Column, Error> CreateColumn(string title, string companyName, Guid companyOwner, int order, PricePlan plan, Subscription subscription)
        {
            if (OwnerId != companyOwner && CompanyName != companyName) throw new Exception("asdasd");

            if (subscription.Id != SubscriptionId) return new Error("", "");

            if (plan.MaxCollumnAllowed >= Columns.Count) return new Error("", "");

            var col = Column.CreateBoard(title, companyName, companyOwner, order);

            Columns.Add(col.Id);

            return col;
            //AddEvent(new ColumnHasBeenAdded());
        }

        //public Result RemoveUserFromDesk(Guid whoRemovingId, Guid userToRemoveId)
        //{
        //    if(whoRemovingId != OwnerId || )
        //    {

        //    }
        //}
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
