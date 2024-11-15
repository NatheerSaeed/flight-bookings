namespace FlightReservationManagement.APIs.Dtos;

public class MarkdownsWhereInput
{
    public string? AirlineCode { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public int? TypeField { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? Value { get; set; }
}
