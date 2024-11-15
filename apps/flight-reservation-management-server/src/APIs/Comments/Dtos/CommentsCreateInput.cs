namespace FlightReservationManagement.APIs.Dtos;

public class CommentCreateInput
{
    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? Id { get; set; }

    public string? Ip { get; set; }

    public string? Name { get; set; }

    public DateTime UpdatedAt { get; set; }
}
