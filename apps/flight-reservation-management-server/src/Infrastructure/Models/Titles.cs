using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("Titles")]
public class TitlesDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public List<ProfilesDbModel>? ProfilesItems { get; set; } = new List<ProfilesDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
