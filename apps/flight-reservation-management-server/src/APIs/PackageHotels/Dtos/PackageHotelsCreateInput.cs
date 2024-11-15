namespace FlightReservationManagement.APIs.Dtos;

public class PackageHotelCreateInput
{
    public string? Address { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? GalleryId { get; set; }

    public string? HotelInfo { get; set; }

    public string? HotelLocation { get; set; }

    public string? HotelName { get; set; }

    public int? HotelStarRating { get; set; }

    public string? Id { get; set; }

    public Packages? PackageField { get; set; }

    public DateTime UpdatedAt { get; set; }
}
