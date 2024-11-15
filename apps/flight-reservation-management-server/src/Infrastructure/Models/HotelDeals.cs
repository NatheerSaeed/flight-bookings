using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("HotelDeals")]
public class HotelDealsDbModel
{
    [StringLength(1000)]
    public string? Address { get; set; }

    [StringLength(1000)]
    public string? City { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Information { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    public string? PackageFieldId { get; set; }

    [ForeignKey(nameof(PackageFieldId))]
    public PackagesDbModel? PackageField { get; set; } = null;

    [Range(-999999999, 999999999)]
    public int? StarRating { get; set; }

    [StringLength(1000)]
    public string? StayDuration { get; set; }

    [StringLength(1000)]
    public string? StayEndDate { get; set; }

    [StringLength(1000)]
    public string? StayStartDate { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
