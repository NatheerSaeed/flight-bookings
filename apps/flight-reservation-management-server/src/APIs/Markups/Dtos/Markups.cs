namespace FlightReservationManagement.APIs.Dtos;

public class Markups
{
    public int? CarMarkupType { get; set; }

    public int? CarMarkupValue { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? FlightMarkupType { get; set; }

    public int? FlightMarkupValue { get; set; }

    public int? HotelMarkupType { get; set; }

    public int? HotelMarkupValue { get; set; }

    public string Id { get; set; }

    public int? PackageMarkupType { get; set; }

    public int? PackageMarkupValue { get; set; }

    public string? Role { get; set; }

    public DateTime UpdatedAt { get; set; }
}
