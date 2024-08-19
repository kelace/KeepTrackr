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
        const int Max_Labels_Count_Allowed = 10;

        public string Title { get; private set; }
        public Guid BoardId { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime CompletionDate { get; private set; }
        public CompanyId CompanyId { get; private set; }
        public List<Label> Labels { get; private set; }
        public List<CardTask> Tasks { get; private set; }

        public int Order { get; private set; }

        public void Update(string name, DateTime? dateCompletion, Guid? assignedUser)
        {
            if(!string.IsNullOrEmpty(name)) Title = name;
            if(dateCompletion.HasValue) CompletionDate = dateCompletion.Value;
        }

        public void Reorder(int order)
        {
            Order = order;
        }
        public void ChangeBoard(Guid boardId)
        {
            BoardId = boardId;
        }

        public void AddTask(string name)
        {
            Tasks.Add(new CardTask(name));
        }

        public void AddLabel(string title, string color)
        {
            if(Labels.Count >= Max_Labels_Count_Allowed)
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
