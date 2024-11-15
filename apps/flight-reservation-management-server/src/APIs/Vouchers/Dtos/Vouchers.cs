namespace FlightReservationManagement.APIs.Dtos;

public class Vouchers
{
    public int? Amount { get; set; }

    public string? Code { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<string>? FlightBookingsItems { get; set; }

    public List<string>? HotelBookingsItems { get; set; }

    public string Id { get; set; }

    public int? Status { get; set; }

    public DateTime UpdatedAt { get; set; }
}
