using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("Vouchers")]
public class VouchersDbModel
{
    [Range(-999999999, 999999999)]
    public int? Amount { get; set; }

    [StringLength(1000)]
    public string? Code { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public List<FlightBookingsDbModel>? FlightBookingsItems { get; set; } =
        new List<FlightBookingsDbModel>();

    public List<HotelBookingsDbModel>? HotelBookingsItems { get; set; } =
        new List<HotelBookingsDbModel>();

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public int? Status { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
