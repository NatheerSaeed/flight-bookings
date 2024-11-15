using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("Attractions")]
public class Attraction
{
    [StringLength(1000)]
    public string? Address { get; set; }

    [StringLength(1000)]
    public string? City { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Date { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Information { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    public string? PackageFieldId { get; set; }

    [ForeignKey(nameof(PackageFieldId))]
    public Package? PackageField { get; set; } = null;

    public List<SightSeeing>? SightSeeingsItems { get; set; } = new List<SightSeeing>();

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
