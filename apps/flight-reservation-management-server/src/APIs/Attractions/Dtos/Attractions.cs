namespace FlightReservationManagement.APIs.Dtos;

public class Attractions
{
    public string? Address { get; set; }

    public string? City { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Date { get; set; }

    public string Id { get; set; }

    public string? Information { get; set; }

    public string? Name { get; set; }

    public string? PackageField { get; set; }

    public List<string>? SightSeeingsItems { get; set; }

    public DateTime UpdatedAt { get; set; }
}
