namespace FlightReservationManagement.APIs.Dtos;

public class PackageBookingCreateInput
{
    public int? Adults { get; set; }

    public int? BookingStatus { get; set; }

    public int? Children { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CustomerEmail { get; set; }

    public string? CustomerFirstName { get; set; }

    public string? CustomerOtherName { get; set; }

    public string? CustomerPhone { get; set; }

    public string? CustomerSurName { get; set; }

    public string? CustomerTitleId { get; set; }

    public string? Id { get; set; }

    public int? Infants { get; set; }

    public Packages? PackageField { get; set; }

    public int? PaymentStatus { get; set; }

    public string? Reference { get; set; }

    public double? TotalAmount { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User? User { get; set; }
}
