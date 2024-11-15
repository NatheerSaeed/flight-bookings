namespace FlightReservationManagement.APIs.Dtos;

public class WalletsCreateInput
{
    public double? Balance { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User? User { get; set; }
}
