using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("Roles")]
public class Role
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(1000)]
    public string? DisplayName { get; set; }

    public List<Hotel>? HotelsItems { get; set; } = new List<Hotel>();

    [Key()]
    [Required()]
    public string Id { get; set; }

    public List<Markup>? MarkupsItems { get; set; } = new List<Markup>();

    [StringLength(1000)]
    public string? Name { get; set; }

    [StringLength(1000)]
    public string? PermissionId { get; set; }

    public string? RoleId { get; set; }

    [ForeignKey(nameof(RoleId))]
    public Role? ContainerRole { get; set; } = null;

    public List<Role>? RolesItems { get; set; } = new List<Role>();

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
