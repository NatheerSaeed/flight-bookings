namespace FlightReservationManagement.APIs.Dtos;

public class WalletLogsCreateInput
{
    public double? Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public int? Status { get; set; }

    public string? TypeId { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User? User { get; set; }
}
