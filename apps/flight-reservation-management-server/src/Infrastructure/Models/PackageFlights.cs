using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("PackageFlights")]
public class PackageFlight
{
    [StringLength(1000)]
    public string? Airline { get; set; }

    [StringLength(1000)]
    public string? ArrivalDateTime { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? DepartureDateTime { get; set; }

    [StringLength(1000)]
    public string? FromLocation { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public string? PackageFieldId { get; set; }

    [ForeignKey(nameof(PackageFieldId))]
    public Package? PackageField { get; set; } = null;

    [StringLength(1000)]
    public string? ToLocation { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
