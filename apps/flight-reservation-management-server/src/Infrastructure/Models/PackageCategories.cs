using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("PackageCategories")]
public class PackageCategoriesDbModel
{
    [StringLength(1000)]
    public string? Category { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public int? Status { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
