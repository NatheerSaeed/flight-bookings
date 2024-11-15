using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("Banks")]
public class Bank
{
    public List<BankDetail>? BankDetailsItems { get; set; } = new List<BankDetail>();

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
