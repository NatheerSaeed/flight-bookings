namespace FlightReservationManagement.APIs.Dtos;

public class PackageFlightsUpdateInput
{
    public string? Airline { get; set; }

    public string? ArrivalDateTime { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? DepartureDateTime { get; set; }

    public string? FromLocation { get; set; }

    public string? Id { get; set; }

    public string? PackageField { get; set; }

    public string? ToLocation { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
