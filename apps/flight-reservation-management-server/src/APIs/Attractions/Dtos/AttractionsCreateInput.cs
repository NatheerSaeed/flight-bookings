namespace FlightReservationManagement.APIs.Dtos;

public class AttractionCreateInput
{
    public string? Address { get; set; }

    public string? City { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Date { get; set; }

    public string? Id { get; set; }

    public string? Information { get; set; }

    public string? Name { get; set; }

    public Packages? PackageField { get; set; }

    public List<SightSeeings>? SightSeeingsItems { get; set; }

    public DateTime UpdatedAt { get; set; }
}
