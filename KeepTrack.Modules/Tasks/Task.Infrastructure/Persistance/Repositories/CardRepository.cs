using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Cards;

namespace TaskManagment.Infrastructure.Persistance.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly TaskContext _context;

        public CardRepository(TaskContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task Add(Card card)
        {
            await _context.Cards.AddAsync(card);
        }

        public async Task<Card> Get(Guid id)
        {
           return await _context.Cards.Include(x => x.Labels).Include(x => x.Tasks).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Card>> GetBoardsAsync(Guid userId, string company)
        {
            return await _context.Cards.Where(x => x.CompanyId.CompanyOwnerId == userId && x.CompanyId.CompanyName == company).ToListAsync();
        }

        public void Update(Card card)
        {
            _context.Update(card);
        }

        public void UpdateRange(List<Card> cards)
        {
            _context.Cards.UpdateRange(cards);
        }
    }
}
