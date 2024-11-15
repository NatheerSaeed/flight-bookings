using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("CarBookings")]
public class CarBookingsDbModel
{
    [Range(-999999999, 999999999)]
    public double? Amount { get; set; }

    [StringLength(1000)]
    public string? BookingReference { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? DropoffDate { get; set; }

    [StringLength(1000)]
    public string? DropoffLocation { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? PickupDate { get; set; }

    [StringLength(1000)]
    public string? PickupLocation { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;

    [StringLength(1000)]
    public string? VehicleId { get; set; }
}
