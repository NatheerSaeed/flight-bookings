using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("BankDetails")]
public class BankDetail
{
    [StringLength(1000)]
    public string? AccountName { get; set; }

    [StringLength(1000)]
    public string? AccountNumber { get; set; }

    public string? BankId { get; set; }

    [ForeignKey(nameof(BankId))]
    public Bank? Bank { get; set; } = null;

    [StringLength(1000)]
    public string? BankBranch { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? IfscCode { get; set; }

    [StringLength(1000)]
    public string? Pan { get; set; }

    [Range(-999999999, 999999999)]
    public int? Status { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
