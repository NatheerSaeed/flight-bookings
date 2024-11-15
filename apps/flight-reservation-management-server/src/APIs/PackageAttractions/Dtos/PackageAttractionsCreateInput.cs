namespace FlightReservationManagement.APIs.Dtos;

public class PackageAttractionCreateInput
{
    public string? Address { get; set; }

    public string? AttractionName { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public Packages? PackageField { get; set; }

    public DateTime UpdatedAt { get; set; }
}
