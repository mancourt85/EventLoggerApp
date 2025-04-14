using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EventLogsRepository : Repository<EventLog>, IEventLogsRepository
    {
        public EventLogsRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<EventLog>> GetByTypeAsync(string logType)
        {
            try
            {
                return await _dbSet.Where(e => e.LogType == logType).ToListAsync();
            }
            catch
            {
                return Enumerable.Empty<EventLog>();
            }
        }

        public async Task<IEnumerable<EventLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                return await _dbSet.Where(e => e.DateEvent >= startDate && e.DateEvent <= endDate)
                                   .ToListAsync();
            }
            catch
            {
                return Enumerable.Empty<EventLog>();
            }
        }

    }
}
