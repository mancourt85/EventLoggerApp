using Domain.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private bool _disposed = false;

        public IEventLogsRepository EventLogs { get; }

        public UnitOfWork(Context context, IEventLogsRepository eventLogsRepository)
        {
            _context = context;
            EventLogs = eventLogsRepository;
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
