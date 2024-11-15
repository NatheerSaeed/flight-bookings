namespace FlightReservationManagement.APIs.Dtos;

public class BankDetails
{
    public string? AccountName { get; set; }

    public string? AccountNumber { get; set; }

    public string? Bank { get; set; }

    public string? BankBranch { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Id { get; set; }

    public string? IfscCode { get; set; }

    public string? Pan { get; set; }

    public int? Status { get; set; }

    public DateTime UpdatedAt { get; set; }
}
