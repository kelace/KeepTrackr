using Authorization.Infastructure;
using Companies.Infrastructure;
using KeepTrack.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Subscription.Infrastructure;
using TaskManagment.Infrastructure.Persistance;

namespace Employees.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public EmployeeDbContext _employeeContext;
        public CompanyDbContext _companyContext;
        public AuthContext _identityContext;
        public SubscriptionContext _subscriptionContext;
        public TaskContext _taskContext;
        public IMediator _mediator;
        private IDbContextTransaction _employeeTransaction;
        private IDbContextTransaction _companyTransaction;
        private IDbContextTransaction _identityTransaction;
        private IDbContextTransaction _taskTransaction;
        public UnitOfWork(EmployeeDbContext employeeContext, CompanyDbContext companyDbContext, AuthContext identityContext, IMediator mediator, TaskContext taskContext, SubscriptionContext subscriptionContext)
        {
            _companyContext = companyDbContext;
            _employeeContext = employeeContext;
            _identityContext = identityContext;
            _taskContext = taskContext;
            _mediator = mediator;
            _subscriptionContext = subscriptionContext;
        }
        public async Task BeginTransaction()
        {
            _employeeTransaction = await _employeeContext.Database.BeginTransactionAsync();
            _companyTransaction = await _companyContext.Database.BeginTransactionAsync();
            _identityTransaction = await _identityContext.Database.BeginTransactionAsync();
            _subscriptionTransaction = await _subscriptionContext.Database.BeginTransactionAsync();
            _taskTransaction = await _taskContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            await _employeeTransaction.CommitAsync();
            await _companyTransaction.CommitAsync();
            await _identityTransaction.CommitAsync();
            await _subscriptionTransaction.CommitAsync();
            await _taskTransaction.CommitAsync();
        }

        public async Task RollBackTransaction()
        {
            await _employeeTransaction.RollbackAsync();
            await _companyTransaction.RollbackAsync();
            await _identityTransaction.RollbackAsync();
            await _subscriptionTransaction.RollbackAsync();
            await _taskTransaction.RollbackAsync();
        }

        public void Dispose()
        {
            if(_employeeTransaction is not null) _employeeTransaction.Dispose();
            if (_companyTransaction is not null) _companyTransaction.Dispose();
            if (_identityTransaction is not null) _identityTransaction.Dispose();
            if (_subscriptionTransaction is not null) _subscriptionTransaction.Dispose();
            if (_taskTransaction is not null) _taskTransaction.Dispose();
        }

        public async Task SaveAsync()
        {
            var employeeEntities = _employeeContext.ChangeTracker.Entries<EntityBase>().Where(x => x.Entity.Events != null && x.Entity.Events.Any()).ToList();
            var companiesEntities = _companyContext.ChangeTracker.Entries<EntityBase>().Where(x => x.Entity.Events != null && x.Entity.Events.Any()).ToList();
            var subscriptionsEntities = _companyContext.ChangeTracker.Entries<EntityBase>().Where(x => x.Entity.Events != null && x.Entity.Events.Any()).ToList();
            var entities = employeeEntities.Union(companiesEntities).Union(subscriptionsEntities).ToList();

            var events = entities.SelectMany(x => x.Entity.Events).ToList();

            entities.ForEach(x => x.Entity.ClearEvents());

            foreach (var e in events)
            {
                await _mediator.Publish(e);
            }

            await _employeeContext.SaveChangesAsync();
            await _companyContext.SaveChangesAsync();
            await _identityContext.SaveChangesAsync();
            await _subscriptionContext.SaveChangesAsync();
            await _taskContext.SaveChangesAsync();
        }
    }
}
