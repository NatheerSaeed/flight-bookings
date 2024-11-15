namespace FlightReservationManagement.APIs.Dtos;

public class TravelPackageWhereInput
{
    public double? AdultPrice { get; set; }

    public int? Attraction { get; set; }

    public string? CategoryId { get; set; }

    public double? ChildPrice { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? Flight { get; set; }

    public int? Hotel { get; set; }

    public string? Id { get; set; }

    public double? InfantPrice { get; set; }

    public string? Information { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public int? Status { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
