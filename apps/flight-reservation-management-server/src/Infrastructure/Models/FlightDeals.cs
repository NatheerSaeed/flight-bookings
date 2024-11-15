using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("FlightDeals")]
public class FlightDealsDbModel
{
    [StringLength(1000)]
    public string? Airline { get; set; }

    [StringLength(1000)]
    public string? Cabin { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Date { get; set; }

    [StringLength(1000)]
    public string? Destination { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Information { get; set; }

    [StringLength(1000)]
    public string? Origin { get; set; }

    public string? PackageFieldId { get; set; }

    [ForeignKey(nameof(PackageFieldId))]
    public PackagesDbModel? PackageField { get; set; } = null;

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
