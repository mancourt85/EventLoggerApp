using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class EventLog
{
    [Key]
    public long Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string LogType { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "VARCHAR(MAX)")]
    public string Content { get; set; } = string.Empty;

    [Column(TypeName = "DATETIME2")]
    public DateTime DateEvent { get; set; } = DateTime.UtcNow;
}
