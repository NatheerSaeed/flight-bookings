using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("Galleries")]
public class Gallerie
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? ImagePath { get; set; }

    [StringLength(1000)]
    public string? ImageTypeId { get; set; }

    public string? PackageFieldId { get; set; }

    [ForeignKey(nameof(PackageFieldId))]
    public Package? PackageField { get; set; } = null;

    [StringLength(1000)]
    public string? ParentId { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
