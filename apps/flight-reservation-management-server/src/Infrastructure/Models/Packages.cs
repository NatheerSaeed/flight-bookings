using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("Packages")]
public class PackagesDbModel
{
    public List<AttractionsDbModel>? AttractionsItems { get; set; } =
        new List<AttractionsDbModel>();

    [Required()]
    public DateTime CreatedAt { get; set; }

    public List<FlightDealsDbModel>? FlightDealsItems { get; set; } =
        new List<FlightDealsDbModel>();

    public List<GalleriesDbModel>? GalleriesItems { get; set; } = new List<GalleriesDbModel>();

    public List<GoodToKnowsDbModel>? GoodToKnowsItems { get; set; } =
        new List<GoodToKnowsDbModel>();

    public List<HotelDealsDbModel>? HotelDealsItems { get; set; } = new List<HotelDealsDbModel>();

    [Key()]
    [Required()]
    public string Id { get; set; }

    public List<PackageAttractionsDbModel>? PackageAttractionsItems { get; set; } =
        new List<PackageAttractionsDbModel>();

    public List<PackageBookingsDbModel>? PackageBookingsItems { get; set; } =
        new List<PackageBookingsDbModel>();

    public List<PackageFlightsDbModel>? PackageFlightsItems { get; set; } =
        new List<PackageFlightsDbModel>();

    public List<PackageHotelsDbModel>? PackageHotelsItems { get; set; } =
        new List<PackageHotelsDbModel>();

    public List<SightSeeingsDbModel>? SightSeeingsItems { get; set; } =
        new List<SightSeeingsDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
