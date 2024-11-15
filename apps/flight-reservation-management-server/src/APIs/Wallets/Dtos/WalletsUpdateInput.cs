namespace FlightReservationManagement.APIs.Dtos;

public class WalletsUpdateInput
{
    public double? Balance { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? User { get; set; }
}
