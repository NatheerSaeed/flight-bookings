namespace FlightReservationManagement.APIs.Dtos;

public class FlightDealCreateInput
{
    public string? Airline { get; set; }

    public string? Cabin { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Date { get; set; }

    public string? Destination { get; set; }

    public string? Id { get; set; }

    public string? Information { get; set; }

    public string? Origin { get; set; }

    public Packages? PackageField { get; set; }

    public DateTime UpdatedAt { get; set; }
}
