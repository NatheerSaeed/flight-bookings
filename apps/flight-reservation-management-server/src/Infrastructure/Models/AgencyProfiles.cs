using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("AgencyProfiles")]
public class AgencyProfilesDbModel
{
    [StringLength(1000)]
    public string? CacRcNumber { get; set; }

    [StringLength(1000)]
    public string? CompanyAddress { get; set; }

    [StringLength(1000)]
    public string? CompanyContactPersonAddress { get; set; }

    [StringLength(1000)]
    public string? CompanyContactPersonEmail { get; set; }

    [StringLength(1000)]
    public string? CompanyContactPersonPhoneNumber { get; set; }

    [StringLength(1000)]
    public string? CompanyEmail { get; set; }

    [StringLength(1000)]
    public string? CompanyName { get; set; }

    [StringLength(1000)]
    public string? CompanyPhoneNumber { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;
}
