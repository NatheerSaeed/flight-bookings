using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("FlightBookings")]
public class FlightBooking
{
    [Range(-999999999, 999999999)]
    public int? CancelTicketStatus { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public int? IssueTicketStatus { get; set; }

    [Range(-999999999, 999999999)]
    public double? ItineraryAmount { get; set; }

    [Range(-999999999, 999999999)]
    public double? Markdown { get; set; }

    [Range(-999999999, 999999999)]
    public double? Markup { get; set; }

    [Range(-999999999, 999999999)]
    public int? PaymentStatus { get; set; }

    [StringLength(1000)]
    public string? Pnr { get; set; }

    [StringLength(1000)]
    public string? PnrRequestResponse { get; set; }

    [StringLength(1000)]
    public string? Reference { get; set; }

    [StringLength(1000)]
    public string? TicketTimeLimit { get; set; }

    [Range(-999999999, 999999999)]
    public double? TotalAmount { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;

    [Range(-999999999, 999999999)]
    public double? Vat { get; set; }

    [Range(-999999999, 999999999)]
    public int? VoidTicketStatus { get; set; }

    public string? VoucherId { get; set; }

    [ForeignKey(nameof(VoucherId))]
    public Voucher? Voucher { get; set; } = null;

    [Range(-999999999, 999999999)]
    public double? VoucherAmount { get; set; }
}
