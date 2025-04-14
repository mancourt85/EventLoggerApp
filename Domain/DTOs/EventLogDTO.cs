using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class EventLogDto
    {
        public string LogType { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime EventDate { get; set; } = DateTime.UtcNow;
    }

}
