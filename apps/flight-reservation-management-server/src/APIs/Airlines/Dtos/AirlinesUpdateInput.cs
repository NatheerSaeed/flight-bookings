namespace FlightReservationManagement.APIs.Dtos;

public class AirlineUpdateInput
{
    public double? Amount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public int? PaymentStatus { get; set; }

    public string? Reference { get; set; }

    public string? ResponseCode { get; set; }

    public string? ResponseDescription { get; set; }

    public string? ResponseFull { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? User { get; set; }
}
