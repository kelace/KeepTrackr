using Executing.Domain.CardAggregate;
using Executing.Domain.UserAggregate;
using KeepTrack.Common;
using KeepTrackr.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executing.Domain.ColumnAggregate
{
    public class Column : EntityBaseWithCustomId, IAggregateRoot
    {
        public new ColumnId Id { get; private set; }
        public string Title { get; private set; }
        public DateTime Created { get; private set; }
        public Guid DeskID { get; private set; }
        public List<CardId> Cards { get; private set; }
        public Guid OwnerId { get; private set; }
        //public const int MaxCardsAllowed = 20;
        //public CompanyId CompanyId { get; private set; }
        public int Order { get; private set; }

        internal Column(ColumnId id, string title, Guid deskId)
        {
            Created = DateTime.UtcNow;
        }

        public Result<Column, Error> MoveTo(int position, User user)
        {
            var isAllow = user.IsAllowToMoveColum;
            if (!isAllow) return new Error("", "");
            Order = position;
            return this;
        }
        //public void Reorder(int order)
        //{
        //    Order = order;
        //}
        public void UpdateTitle(string title)
        {
            Title = title;
            //Order = order;
        }
        //public Card AddCard(string title)
        //{
        //    if (CardsCount >= MaxCardsAllowed) throw new Exception("asdasd");
        //    CardsCount++;
        //    return Card.CreateCard(title, CompanyId.CompanyName, CompanyId.CompanyOwnerId);
        //}

        internal static Column CreateBoard(string title, string companyName, Guid companyOwner, int order)
        {
            return new Column(new ColumnId(), title, order);
        }
    }
}
