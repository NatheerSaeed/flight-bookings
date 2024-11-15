using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationManagement.Infrastructure.Models;

[Table("VisaApplications")]
public class VisaApplicationsDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? DestinationCountry { get; set; }

    public string? Email { get; set; }

    [StringLength(1000)]
    public string? GivenName { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? IpAddress { get; set; }

    [StringLength(1000)]
    public string? Phone { get; set; }

    [StringLength(1000)]
    public string? ResidenceCountry { get; set; }

    [StringLength(1000)]
    public string? Surname { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
