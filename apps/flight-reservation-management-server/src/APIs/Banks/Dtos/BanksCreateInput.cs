namespace FlightReservationManagement.APIs.Dtos;

public class BanksCreateInput
{
    public List<BankDetails>? BankDetailsItems { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public DateTime UpdatedAt { get; set; }
}
