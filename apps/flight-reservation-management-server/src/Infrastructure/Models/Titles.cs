using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("Titles")]
public class Title
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public List<Profile>? ProfilesItems { get; set; } = new List<Profile>();

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
