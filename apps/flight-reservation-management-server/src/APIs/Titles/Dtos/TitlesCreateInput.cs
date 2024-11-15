namespace FlightReservationManagement.APIs.Dtos;

public class TitlesCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public List<Profiles>? ProfilesItems { get; set; }

    public DateTime UpdatedAt { get; set; }
}
