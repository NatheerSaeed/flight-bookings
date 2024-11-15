namespace FlightReservationManagement.APIs.Dtos;

public class RolesUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Description { get; set; }

    public string? DisplayName { get; set; }

    public List<string>? HotelsItems { get; set; }

    public string? Id { get; set; }

    public List<string>? MarkupsItems { get; set; }

    public string? Name { get; set; }

    public string? PermissionId { get; set; }

    public string? Role { get; set; }

    public List<string>? RolesItems { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
