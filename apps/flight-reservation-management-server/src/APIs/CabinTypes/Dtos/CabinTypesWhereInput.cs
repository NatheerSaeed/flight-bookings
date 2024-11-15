namespace FlightReservationManagement.APIs.Dtos;

public class CabinTypesWhereInput
{
    public string? CabinCode { get; set; }

    public string? CabinName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
