using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("Profiles")]
public class ProfilesDbModel
{
    [StringLength(1000)]
    public string? Address { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? FirstName { get; set; }

    public string? GenderId { get; set; }

    [ForeignKey(nameof(GenderId))]
    public GendersDbModel? Gender { get; set; } = null;

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? OtherName { get; set; }

    [StringLength(1000)]
    public string? PhoneNumber { get; set; }

    [StringLength(1000)]
    public string? Photo { get; set; }

    [StringLength(1000)]
    public string? SurName { get; set; }

    public string? TitleId { get; set; }

    [ForeignKey(nameof(TitleId))]
    public TitlesDbModel? Title { get; set; } = null;

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;
}
