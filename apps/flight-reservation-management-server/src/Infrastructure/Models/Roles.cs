using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("Roles")]
public class RolesDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(1000)]
    public string? DisplayName { get; set; }

    public List<HotelsDbModel>? HotelsItems { get; set; } = new List<HotelsDbModel>();

    [Key()]
    [Required()]
    public string Id { get; set; }

    public List<MarkupsDbModel>? MarkupsItems { get; set; } = new List<MarkupsDbModel>();

    [StringLength(1000)]
    public string? Name { get; set; }

    [StringLength(1000)]
    public string? PermissionId { get; set; }

    public string? RoleId { get; set; }

    [ForeignKey(nameof(RoleId))]
    public RolesDbModel? Role { get; set; } = null;

    public List<RolesDbModel>? RolesItems { get; set; } = new List<RolesDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
