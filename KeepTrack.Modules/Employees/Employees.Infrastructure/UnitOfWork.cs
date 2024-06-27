using Employees.Domain;
using Employees.Domain.Base;
using MediatR;

namespace Employees.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public EmployeeDbContext _context;
        public IMediator _mediator;
        public UnitOfWork(EmployeeDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task SaveAsync()
        {
            var entities = _context.ChangeTracker.Entries<AggregateRoot>().Where(x => x.Entity.Events != null && x.Entity.Events.Any()).ToList();

            var events = entities.SelectMany(x => x.Entity.Events).ToList();

            entities.ForEach(x => x.Entity.ClearEvents());


            foreach (var e in events)
            {
                await _mediator.Publish(e);
            }
            await _context.SaveChangesAsync();

        }
    }
}
