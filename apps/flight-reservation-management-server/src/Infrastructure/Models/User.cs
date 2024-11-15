using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("Users")]
public class UserDbModel
{
    public List<AgencyProfile>? AgencyProfilesItems { get; set; } = new List<AgencyProfile>();

    public List<Airline>? AirlinesItems { get; set; } = new List<Airline>();

    [StringLength(1000)]
    public string? ApiToken { get; set; }

    public List<BankPayment>? BankPaymentsItems { get; set; } = new List<BankPayment>();

    public List<CarBooking>? CarBookingsItems { get; set; } = new List<CarBooking>();

    public List<CooperateCustomerProfile>? CooperateCustomerProfilesItems { get; set; } =
        new List<CooperateCustomerProfile>();

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Range(-999999999, 999999999)]
    public int? DeleteStatus { get; set; }

    public string? Email { get; set; }

    [StringLength(256)]
    public string? FirstName { get; set; }

    public List<FlightBooking>? FlightBookingsItems { get; set; } = new List<FlightBooking>();

    public List<HotelBooking>? HotelBookingsItems { get; set; } = new List<HotelBooking>();

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(256)]
    public string? LastName { get; set; }

    public List<OnlinePayment>? OnlinePaymentsItems { get; set; } = new List<OnlinePayment>();

    public List<PackageBooking>? PackageBookingsItems { get; set; } = new List<PackageBooking>();

    [Required()]
    public string Password { get; set; }

    public List<PayLater>? PayLatersItems { get; set; } = new List<PayLater>();

    [Range(-999999999, 999999999)]
    public int? ProfileCompleteStatus { get; set; }

    public List<Profile>? ProfilesItems { get; set; } = new List<Profile>();

    [Required()]
    public string Roles { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [Required()]
    public string Username { get; set; }

    public List<WalletLog>? WalletLogsItems { get; set; } = new List<WalletLog>();

    public List<Wallet>? WalletsItems { get; set; } = new List<Wallet>();
}
