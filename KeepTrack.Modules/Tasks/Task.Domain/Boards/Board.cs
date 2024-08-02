using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Cards;

namespace TaskManagment.Domain.Boards
{
    public class Board : EntityBase, IAggregateRoot
    {
        public string Title { get; private set; }
        public DateTime Created { get; private set; }
        public int CardsCount { get; private set; }

        public const int MaxCardsAllowed = 20;
        public CompanyId CompanyId { get; private set; }
        public int Order { get; private set; }

        public void Reorder(int order)
        {
            Order = order;
        }
        public void Update(string title, int order)
        {
            Title = title;
            Order = order;
        }
        public Card AddCard(string title)
        {
            if (CardsCount >= MaxCardsAllowed) throw new Exception("asdasd");
            CardsCount++;
            return Card.CreateCard(title, CompanyId.CompanyName, CompanyId.CompanyOwnerId);
        }

        internal static Board CreateBoard(string title, string companyName, Guid companyOwner, int order)
        {
            return new Board
            {
                Id = Guid.NewGuid(),
                Title = title,
                Created = DateTime.UtcNow,
                CardsCount = 0,
                CompanyId = new CompanyId
                {
                    CompanyName = companyName,
                    CompanyOwnerId = companyOwner
                },
                Order = order
            };
        }
    }
}
