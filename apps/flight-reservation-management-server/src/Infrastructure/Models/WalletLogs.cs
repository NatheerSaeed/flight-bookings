using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("WalletLogs")]
public class WalletLog
{
    [Range(-999999999, 999999999)]
    public double? Amount { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public int? Status { get; set; }

    [StringLength(1000)]
    public string? TypeId { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;
}
