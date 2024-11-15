namespace FlightReservationManagement.APIs.Dtos;

public class PackagesCreateInput
{
    public List<Attractions>? AttractionsItems { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<FlightDeals>? FlightDealsItems { get; set; }

    public List<Galleries>? GalleriesItems { get; set; }

    public List<GoodToKnows>? GoodToKnowsItems { get; set; }

    public List<HotelDeals>? HotelDealsItems { get; set; }

    public string? Id { get; set; }

    public List<PackageAttractions>? PackageAttractionsItems { get; set; }

    public List<PackageBookings>? PackageBookingsItems { get; set; }

    public List<PackageFlights>? PackageFlightsItems { get; set; }

    public List<PackageHotels>? PackageHotelsItems { get; set; }

    public List<SightSeeings>? SightSeeingsItems { get; set; }

    public DateTime UpdatedAt { get; set; }
}
