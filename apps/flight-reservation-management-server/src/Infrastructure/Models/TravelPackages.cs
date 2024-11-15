using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("TravelPackages")]
public class TravelPackage
{
    [Range(-999999999, 999999999)]
    public double? AdultPrice { get; set; }

    [Range(-999999999, 999999999)]
    public int? Attraction { get; set; }

    [StringLength(1000)]
    public string? CategoryId { get; set; }

    [Range(-999999999, 999999999)]
    public double? ChildPrice { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Range(-999999999, 999999999)]
    public int? Flight { get; set; }

    [Range(-999999999, 999999999)]
    public int? Hotel { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public double? InfantPrice { get; set; }

    [StringLength(1000)]
    public string? Information { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [StringLength(1000)]
    public string? PhoneNumber { get; set; }

    [Range(-999999999, 999999999)]
    public int? Status { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
