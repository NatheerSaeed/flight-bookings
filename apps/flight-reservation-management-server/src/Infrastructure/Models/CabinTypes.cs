using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("CabinTypes")]
public class CabinTypesDbModel
{
    [StringLength(1000)]
    public string? CabinCode { get; set; }

    [StringLength(1000)]
    public string? CabinName { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
