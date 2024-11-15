using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("Packages")]
public class Package
{
    public List<Attraction>? AttractionsItems { get; set; } = new List<Attraction>();

    [Required()]
    public DateTime CreatedAt { get; set; }

    public List<FlightDeal>? FlightDealsItems { get; set; } = new List<FlightDeal>();

    public List<Gallerie>? GalleriesItems { get; set; } = new List<Gallerie>();

    public List<GoodToKnow>? GoodToKnowsItems { get; set; } = new List<GoodToKnow>();

    public List<HotelDeal>? HotelDealsItems { get; set; } = new List<HotelDeal>();

    [Key()]
    [Required()]
    public string Id { get; set; }

    public List<PackageAttraction>? PackageAttractionsItems { get; set; } =
        new List<PackageAttraction>();

    public List<PackageBooking>? PackageBookingsItems { get; set; } = new List<PackageBooking>();

    public List<PackageFlight>? PackageFlightsItems { get; set; } = new List<PackageFlight>();

    public List<PackageHotel>? PackageHotelsItems { get; set; } = new List<PackageHotel>();

    public List<SightSeeing>? SightSeeingsItems { get; set; } = new List<SightSeeing>();

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
