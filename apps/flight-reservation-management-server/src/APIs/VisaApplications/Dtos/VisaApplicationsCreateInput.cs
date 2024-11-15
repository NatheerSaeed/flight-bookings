namespace FlightReservationManagement.APIs.Dtos;

public class VisaApplicationCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? DestinationCountry { get; set; }

    public string? Email { get; set; }

    public string? GivenName { get; set; }

    public string? Id { get; set; }

    public string? IpAddress { get; set; }

    public string? Phone { get; set; }

    public string? ResidenceCountry { get; set; }

    public string? Surname { get; set; }

    public DateTime UpdatedAt { get; set; }
}
