namespace FlightReservationManagement.APIs.Dtos;

public class FlightBookingsWhereInput
{
    public int? CancelTicketStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public int? IssueTicketStatus { get; set; }

    public double? ItineraryAmount { get; set; }

    public double? Markdown { get; set; }

    public double? Markup { get; set; }

    public int? PaymentStatus { get; set; }

    public string? Pnr { get; set; }

    public string? PnrRequestResponse { get; set; }

    public string? Reference { get; set; }

    public string? TicketTimeLimit { get; set; }

    public double? TotalAmount { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? User { get; set; }

    public double? Vat { get; set; }

    public int? VoidTicketStatus { get; set; }

    public string? Voucher { get; set; }

    public double? VoucherAmount { get; set; }
}
