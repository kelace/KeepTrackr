using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain.Cards
{
    public class Label : EntityBase
    {
        public string Name { get; private set; }
        public string Color { get; private set; }
        public Guid CardId { get; private set; }

        public Label(string name, string color, Guid cardId)
        {
            Name = name;
            Color = color;
            CardId = cardId;
        }
    }
}
