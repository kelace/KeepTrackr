using Executing.Domain.SubscriptionAggregate;
using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executing.Domain.CardAggregate
{
    public class Card : EntityBase, IAggregateRoot
    {
        //const int Max_Labels_Count_Allowed = 10;

        public string Title { get; private set; }
        public Guid ColumnId { get; private set; }
        public Guid DeskId { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime CompletionDate { get; private set; }
        public CompanyId CompanyId { get; private set; }
        public List<Label> Labels { get; private set; }
        public List<Job> Tasks { get; private set; }
        //public Guid SubscriptionId { get; private set; }

        public int Order { get; private set; }

        public void Update(string name, DateTime? dateCompletion, Guid? assignedUser = null, Guid? columnId = null, int position = 0)
        {
            if(!string.IsNullOrEmpty(name)) Title = name;
            if(dateCompletion.HasValue) CompletionDate = dateCompletion.Value;

            //AddEvent(new UpdateCardEvent
            //{
            //    CardId = Id,
            //    ColumnId = columnId,
            //    Position = position,
            //});
        }

        public void Reorder(int order)
        {
            Order = order;
        }
        public void ChangeBoard(Guid boardId)
        {
            ColumnId = boardId;
        }

        public void AddTask(string name)
        {
            Tasks.Add(new Job(name, Id));
        }

        public void AddLabel(string title, string color, Subscription subscription)
        {
            if(Labels.Count >= subscription.MaxLabelAllowed)
            {
                throw new Exception("Labels Count");
            }

            Labels.Add(new Label(title, color, Id));
        }
        public static Card CreateCard(string title, string companyName, Guid companyOwner, int order, Guid boardId)
        {
            return new Card
            {
                Title = title,
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                Order = order,
                ColumnId = boardId,
                CompanyId = new CompanyId
                {
                    CompanyName = companyName,
                    CompanyOwnerId = companyOwner
                }
            };

        }
    }
}
