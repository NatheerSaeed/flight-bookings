using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("PackageBookings")]
public class PackageBooking
{
    [Range(-999999999, 999999999)]
    public int? Adults { get; set; }

    [Range(-999999999, 999999999)]
    public int? BookingStatus { get; set; }

    [Range(-999999999, 999999999)]
    public int? Children { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? CustomerEmail { get; set; }

    [StringLength(1000)]
    public string? CustomerFirstName { get; set; }

    [StringLength(1000)]
    public string? CustomerOtherName { get; set; }

    [StringLength(1000)]
    public string? CustomerPhone { get; set; }

    [StringLength(1000)]
    public string? CustomerSurName { get; set; }

    [StringLength(1000)]
    public string? CustomerTitleId { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public int? Infants { get; set; }

    public string? PackageFieldId { get; set; }

    [ForeignKey(nameof(PackageFieldId))]
    public Package? PackageField { get; set; } = null;

    [Range(-999999999, 999999999)]
    public int? PaymentStatus { get; set; }

    [StringLength(1000)]
    public string? Reference { get; set; }

    [Range(-999999999, 999999999)]
    public double? TotalAmount { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;
}
