using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("Markups")]
public class Markup
{
    [Range(-999999999, 999999999)]
    public int? CarMarkupType { get; set; }

    [Range(-999999999, 999999999)]
    public int? CarMarkupValue { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Range(-999999999, 999999999)]
    public int? FlightMarkupType { get; set; }

    [Range(-999999999, 999999999)]
    public int? FlightMarkupValue { get; set; }

    [Range(-999999999, 999999999)]
    public int? HotelMarkupType { get; set; }

    [Range(-999999999, 999999999)]
    public int? HotelMarkupValue { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public int? PackageMarkupType { get; set; }

    [Range(-999999999, 999999999)]
    public int? PackageMarkupValue { get; set; }

    public string? RoleId { get; set; }

    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; } = null;

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
