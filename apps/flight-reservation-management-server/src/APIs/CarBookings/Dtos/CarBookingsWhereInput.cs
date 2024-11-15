namespace FlightReservationManagement.APIs.Dtos;

public class CarBookingsWhereInput
{
    public double? Amount { get; set; }

    public string? BookingReference { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? DropoffDate { get; set; }

    public string? DropoffLocation { get; set; }

    public string? Id { get; set; }

    public string? PickupDate { get; set; }

    public string? PickupLocation { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? User { get; set; }

    public string? VehicleId { get; set; }
}
