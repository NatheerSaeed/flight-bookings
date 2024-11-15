using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("PackageHotels")]
public class PackageHotelsDbModel
{
    [StringLength(1000)]
    public string? Address { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? GalleryId { get; set; }

    [StringLength(1000)]
    public string? HotelInfo { get; set; }

    [StringLength(1000)]
    public string? HotelLocation { get; set; }

    [StringLength(1000)]
    public string? HotelName { get; set; }

    [Range(-999999999, 999999999)]
    public int? HotelStarRating { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public string? PackageFieldId { get; set; }

    [ForeignKey(nameof(PackageFieldId))]
    public PackagesDbModel? PackageField { get; set; } = null;

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
