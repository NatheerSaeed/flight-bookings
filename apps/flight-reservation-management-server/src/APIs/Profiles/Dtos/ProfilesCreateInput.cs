namespace FlightReservationManagement.APIs.Dtos;

public class ProfilesCreateInput
{
    public string? Address { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? FirstName { get; set; }

    public Genders? Gender { get; set; }

    public string? Id { get; set; }

    public string? OtherName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Photo { get; set; }

    public string? SurName { get; set; }

    public Titles? Title { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User? User { get; set; }
}
