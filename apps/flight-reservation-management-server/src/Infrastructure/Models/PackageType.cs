using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("PackageTypes")]
public class PackageType
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public int? Status { get; set; }

    [StringLength(1000)]
    public string? TypeField { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
