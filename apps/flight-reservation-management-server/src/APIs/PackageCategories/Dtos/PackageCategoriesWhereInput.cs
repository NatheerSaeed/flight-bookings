namespace FlightReservationManagement.APIs.Dtos;

public class PackageCategorieWhereInput
{
    public string? Category { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public int? Status { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
