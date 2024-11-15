using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("BankPayments")]
public class BankPaymentsDbModel
{
    [Range(-999999999, 999999999)]
    public int? Amount { get; set; }

    [StringLength(1000)]
    public string? BankDetailId { get; set; }

    [StringLength(1000)]
    public string? BookingReference { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Reference { get; set; }

    [StringLength(1000)]
    public string? SlipPhoto { get; set; }

    [Range(-999999999, 999999999)]
    public int? Status { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;
}
