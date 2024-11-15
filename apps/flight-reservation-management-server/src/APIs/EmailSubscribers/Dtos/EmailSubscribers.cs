namespace FlightReservationManagement.APIs.Dtos;

public class EmailSubscribers
{
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    public string Id { get; set; }

    public string? IpAddress { get; set; }

    public DateTime UpdatedAt { get; set; }
}
