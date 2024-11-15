namespace FlightReservationManagement.APIs.Dtos;

public class PasswordResetsCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? Id { get; set; }

    public string? Token { get; set; }

    public DateTime UpdatedAt { get; set; }
}