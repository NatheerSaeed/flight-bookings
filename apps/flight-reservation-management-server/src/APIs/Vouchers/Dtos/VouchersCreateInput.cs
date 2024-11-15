namespace FlightReservationManagement.APIs.Dtos;

public class VoucherCreateInput
{
    public int? Amount { get; set; }

    public string? Code { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<FlightBookings>? FlightBookingsItems { get; set; }

    public List<HotelBookings>? HotelBookingsItems { get; set; }

    public string? Id { get; set; }

    public int? Status { get; set; }

    public DateTime UpdatedAt { get; set; }
}
