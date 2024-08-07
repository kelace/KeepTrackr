using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain.Cards
{
    public interface ICardRepository
    {
        Task<Card> Get(Guid id);
        System.Threading.Tasks.Task Add(Card card);
        void Update(Card card);
        void UpdateRange(List<Card> card);
        Task<List<Card>> GetBoardsAsync(Guid userId, string company);
    }
}
