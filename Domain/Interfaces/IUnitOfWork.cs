using Domain.Interfaces.Repositories;

namespace Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IEventLogsRepository EventLogs { get; }
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
