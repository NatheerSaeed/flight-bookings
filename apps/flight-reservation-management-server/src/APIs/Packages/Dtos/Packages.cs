namespace FlightReservationManagement.APIs.Dtos;

public class Packages
{
    public List<string>? AttractionsItems { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<string>? FlightDealsItems { get; set; }

    public List<string>? HotelDealsItems { get; set; }

    public string Id { get; set; }

    public List<string>? PackageFlightsItems { get; set; }

    public List<string>? PackageHotelsItems { get; set; }

    public List<string>? SightSeeingsItems { get; set; }

    public DateTime UpdatedAt { get; set; }
}
