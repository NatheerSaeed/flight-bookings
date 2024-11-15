using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("HotelBookings")]
public class HotelBookingsDbModel
{
    [Range(-999999999, 999999999)]
    public int? AdultGuest { get; set; }

    [Range(-999999999, 999999999)]
    public double? BaseAmount { get; set; }

    [Range(-999999999, 999999999)]
    public int? CancellationStatus { get; set; }

    [StringLength(1000)]
    public string? CheckInDate { get; set; }

    [StringLength(1000)]
    public string? CheckOutDate { get; set; }

    [Range(-999999999, 999999999)]
    public int? ChildGuest { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? ExpiryDate { get; set; }

    [StringLength(1000)]
    public string? Guarantee { get; set; }

    [StringLength(1000)]
    public string? HotelChainCode { get; set; }

    [StringLength(1000)]
    public string? HotelCityCode { get; set; }

    [StringLength(1000)]
    public string? HotelCode { get; set; }

    [StringLength(1000)]
    public string? HotelContextCode { get; set; }

    [StringLength(1000)]
    public string? HotelName { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

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
    public string? RatePlanCode { get; set; }

    [StringLength(1000)]
    public string? Reference { get; set; }

    [Range(-999999999, 999999999)]
    public int? ReservationStatus { get; set; }

    [StringLength(1000)]
    public string? RoomBookingCode { get; set; }

    [Range(-999999999, 999999999)]
    public double? TotalAmount { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;

    [Range(-999999999, 999999999)]
    public double? Vat { get; set; }

    public string? VoucherId { get; set; }

    [ForeignKey(nameof(VoucherId))]
    public VouchersDbModel? Voucher { get; set; } = null;

    [Range(-999999999, 999999999)]
    public double? VoucherAmount { get; set; }
}
