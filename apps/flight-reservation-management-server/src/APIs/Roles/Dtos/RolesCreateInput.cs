namespace FlightReservationManagement.APIs.Dtos;

public class RolesCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public string? DisplayName { get; set; }

    public List<Hotels>? HotelsItems { get; set; }

    public string? Id { get; set; }

    public List<Markups>? MarkupsItems { get; set; }

    public string? Name { get; set; }

    public string? PermissionId { get; set; }

    public Roles? Role { get; set; }

    public List<Roles>? RolesItems { get; set; }

    public DateTime UpdatedAt { get; set; }
}
