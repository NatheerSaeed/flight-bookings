namespace FlightReservationManagement.APIs.Dtos;

public class HotelDealWhereInput
{
    public string? Address { get; set; }

    public string? City { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Information { get; set; }

    public string? Name { get; set; }

    public string? PackageField { get; set; }

    public int? StarRating { get; set; }

    public string? StayDuration { get; set; }

    public string? StayEndDate { get; set; }

    public string? StayStartDate { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
