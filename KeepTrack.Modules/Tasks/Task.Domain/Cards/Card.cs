using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain.Cards
{
    public class Card : EntityBase, IAggregateRoot
    {
        public string Title { get; private set; }
        public Guid BoardId { get; private set; }
        public DateTime Created { get; private set; }
        public CompanyId CompanyId { get; private set; }
        public int Order { get; private set; }
        public void Reorder(int order)
        {
            Order = order;
        }
        public void ChangeBoard(Guid boardId)
        {
            BoardId = boardId;
        }
        public static Card CreateCard(string title, string companyName, Guid companyOwner, int order, Guid boardId)
        {
            return new Card
            {
                Title = title,
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                Order = order,
                BoardId = boardId,
                CompanyId = new CompanyId
                {
                    CompanyName = companyName,
                    CompanyOwnerId = companyOwner
                }
            };

        }
    }
}
