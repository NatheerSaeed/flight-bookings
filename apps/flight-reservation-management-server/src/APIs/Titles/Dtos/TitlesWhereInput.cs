namespace FlightReservationManagement.APIs.Dtos;

public class TitlesWhereInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public List<string>? ProfilesItems { get; set; }

    public DateTime? UpdatedAt { get; set; }
}