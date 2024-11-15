namespace FlightReservationManagement.APIs.Dtos;

public class SightSeeingsCreateInput
{
    public Attractions? Attraction { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public string? Id { get; set; }

    public Packages? PackageField { get; set; }

    public string? Title { get; set; }

    public DateTime UpdatedAt { get; set; }
}
