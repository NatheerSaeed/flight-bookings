namespace FlightReservationManagement.APIs.Dtos;

public class PackageWhereInput
{
    public List<string>? AttractionsItems { get; set; }

    public DateTime? CreatedAt { get; set; }

    public List<string>? FlightDealsItems { get; set; }

    public List<string>? GalleriesItems { get; set; }

    public List<string>? GoodToKnowsItems { get; set; }

    public List<string>? HotelDealsItems { get; set; }

    public string? Id { get; set; }

    public List<string>? PackageAttractionsItems { get; set; }

    public List<string>? PackageBookingsItems { get; set; }

    public List<string>? PackageFlightsItems { get; set; }

    public List<string>? PackageHotelsItems { get; set; }

    public List<string>? SightSeeingsItems { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
