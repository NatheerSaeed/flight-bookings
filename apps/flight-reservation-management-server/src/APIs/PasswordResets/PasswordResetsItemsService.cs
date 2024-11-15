using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class PasswordResetsItemsService : PasswordResetsItemsServiceBase
{
    public PasswordResetsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
