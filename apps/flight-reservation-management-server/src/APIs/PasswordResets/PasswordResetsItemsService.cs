using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class PasswordResetsService : PasswordResetsServiceBase
{
    public PasswordResetsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
