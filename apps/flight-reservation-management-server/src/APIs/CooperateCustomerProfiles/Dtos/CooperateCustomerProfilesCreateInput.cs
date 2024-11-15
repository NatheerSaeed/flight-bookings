namespace FlightReservationManagement.APIs.Dtos;

public class CooperateCustomerProfilesCreateInput
{
    public string? CompanyAddress { get; set; }

    public string? CompanyCacRcNumber { get; set; }

    public string? CompanyContactPersonAddress { get; set; }

    public string? CompanyContactPersonEmail { get; set; }

    public string? CompanyContactPersonPhoneNumber { get; set; }

    public string? CompanyEmail { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyPhoneNumber { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User? User { get; set; }
}
