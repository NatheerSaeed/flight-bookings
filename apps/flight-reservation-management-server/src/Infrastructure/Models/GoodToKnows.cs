using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("GoodToKnows")]
public class GoodToKnowsDbModel
{
    [StringLength(1000)]
    public string? CancellationPrepayment { get; set; }

    [StringLength(1000)]
    public string? CheckIn { get; set; }

    [StringLength(1000)]
    public string? CheckOut { get; set; }

    [StringLength(1000)]
    public string? ChildrenBeds { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Groups { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Internet { get; set; }

    public string? PackageFieldId { get; set; }

    [ForeignKey(nameof(PackageFieldId))]
    public PackagesDbModel? PackageField { get; set; } = null;

    [StringLength(1000)]
    public string? Pets { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
