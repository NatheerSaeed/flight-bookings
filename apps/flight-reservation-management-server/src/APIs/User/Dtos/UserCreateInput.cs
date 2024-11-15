namespace FlightReservationManagement.APIs.Dtos;

public class UserCreateInput
{
    public List<AgencyProfiles>? AgencyProfilesItems { get; set; }

    public List<Airlines>? AirlinesItems { get; set; }

    public string? ApiToken { get; set; }

    public List<BankPayments>? BankPaymentsItems { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? DeleteStatus { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public List<HotelBookings>? HotelBookingsItems { get; set; }

    public string? Id { get; set; }

    public string? LastName { get; set; }

    public string Password { get; set; }

    public List<PayLaters>? PayLatersItems { get; set; }

    public int? ProfileCompleteStatus { get; set; }

    public List<Profiles>? ProfilesItems { get; set; }

    public string Roles { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Username { get; set; }

    public List<WalletLogs>? WalletLogsItems { get; set; }

    public List<Wallets>? WalletsItems { get; set; }
}
