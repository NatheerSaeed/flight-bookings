namespace FlightReservationManagement.APIs.Dtos;

public class Banks
{
    public List<string>? BankDetailsItems { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Id { get; set; }

    public string? Name { get; set; }

    public DateTime UpdatedAt { get; set; }
}
