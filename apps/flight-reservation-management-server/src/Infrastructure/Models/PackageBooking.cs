using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("PackageBookings")]
public class PackageBookingDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
