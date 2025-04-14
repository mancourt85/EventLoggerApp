using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IEventLogsRepository : IRepository<EventLog>
    {
        Task<IEnumerable<EventLog>> GetByTypeAsync(string logType);
        Task<IEnumerable<EventLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
