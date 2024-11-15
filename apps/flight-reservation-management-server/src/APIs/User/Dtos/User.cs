namespace FlightReservationManagement.APIs.Dtos;

public class User
{
    public List<string>? AgencyProfilesItems { get; set; }

    public List<string>? AirlinesItems { get; set; }

    public string? ApiToken { get; set; }

    public List<string>? BankPaymentsItems { get; set; }

    public List<string>? CarBookingsItems { get; set; }

    public List<string>? CooperateCustomerProfilesItems { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? DeleteStatus { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public List<string>? FlightBookingsItems { get; set; }

    public List<string>? HotelBookingsItems { get; set; }

    public string Id { get; set; }

    public string? LastName { get; set; }

    public List<string>? OnlinePaymentsItems { get; set; }

    public List<string>? PackageBookingsItems { get; set; }

    public string Password { get; set; }

    public List<string>? PayLatersItems { get; set; }

    public int? ProfileCompleteStatus { get; set; }

    public List<string>? ProfilesItems { get; set; }

    public string Roles { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Username { get; set; }

    public List<string>? WalletLogsItems { get; set; }

    public List<string>? WalletsItems { get; set; }
}
