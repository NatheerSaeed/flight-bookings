namespace FlightReservationManagement.APIs.Dtos;

public class PackageTypesUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public int? Status { get; set; }

    public string? TypeField { get; set; }

    public DateTime? UpdatedAt { get; set; }
}