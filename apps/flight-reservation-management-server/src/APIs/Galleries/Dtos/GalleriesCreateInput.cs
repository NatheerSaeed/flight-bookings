namespace FlightReservationManagement.APIs.Dtos;

public class GalleriesCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? ImagePath { get; set; }

    public string? ImageTypeId { get; set; }

    public Packages? PackageField { get; set; }

    public string? ParentId { get; set; }

    public DateTime UpdatedAt { get; set; }
}
