namespace FlightReservationManagement.APIs.Dtos;

public class BankPaymentsWhereInput
{
    public int? Amount { get; set; }

    public string? BankDetailId { get; set; }

    public string? BookingReference { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Reference { get; set; }

    public string? SlipPhoto { get; set; }

    public int? Status { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? User { get; set; }
}
