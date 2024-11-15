namespace FlightReservationManagement.APIs.Dtos;

public class HotelBookingCreateInput
{
    public int? AdultGuest { get; set; }

    public double? BaseAmount { get; set; }

    public int? CancellationStatus { get; set; }

    public string? CheckInDate { get; set; }

    public string? CheckOutDate { get; set; }

    public int? ChildGuest { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? ExpiryDate { get; set; }

    public string? Guarantee { get; set; }

    public string? HotelChainCode { get; set; }

    public string? HotelCityCode { get; set; }

    public string? HotelCode { get; set; }

    public string? HotelContextCode { get; set; }

    public string? HotelName { get; set; }

    public string? Id { get; set; }

    public double? Markdown { get; set; }

    public double? Markup { get; set; }

    public int? PaymentStatus { get; set; }

    public string? Pnr { get; set; }

    public string? PnrRequestResponse { get; set; }

    public string? RatePlanCode { get; set; }

    public string? Reference { get; set; }

    public int? ReservationStatus { get; set; }

    public string? RoomBookingCode { get; set; }

    public double? TotalAmount { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User? User { get; set; }

    public double? Vat { get; set; }

    public Vouchers? Voucher { get; set; }

    public double? VoucherAmount { get; set; }
}
