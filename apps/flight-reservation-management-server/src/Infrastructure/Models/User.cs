using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("Users")]
public class UserDbModel
{
    public List<AgencyProfilesDbModel>? AgencyProfilesItems { get; set; } =
        new List<AgencyProfilesDbModel>();

    public List<AirlinesDbModel>? AirlinesItems { get; set; } = new List<AirlinesDbModel>();

    [StringLength(1000)]
    public string? ApiToken { get; set; }

    public List<BankPaymentsDbModel>? BankPaymentsItems { get; set; } =
        new List<BankPaymentsDbModel>();

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Range(-999999999, 999999999)]
    public int? DeleteStatus { get; set; }

    public string? Email { get; set; }

    [StringLength(256)]
    public string? FirstName { get; set; }

    public List<HotelBookingsDbModel>? HotelBookingsItems { get; set; } =
        new List<HotelBookingsDbModel>();

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(256)]
    public string? LastName { get; set; }

    [Required()]
    public string Password { get; set; }

    public List<PayLatersDbModel>? PayLatersItems { get; set; } = new List<PayLatersDbModel>();

    [Range(-999999999, 999999999)]
    public int? ProfileCompleteStatus { get; set; }

    public List<ProfilesDbModel>? ProfilesItems { get; set; } = new List<ProfilesDbModel>();

    [Required()]
    public string Roles { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [Required()]
    public string Username { get; set; }

    public List<WalletLogsDbModel>? WalletLogsItems { get; set; } = new List<WalletLogsDbModel>();

    public List<WalletsDbModel>? WalletsItems { get; set; } = new List<WalletsDbModel>();
}
