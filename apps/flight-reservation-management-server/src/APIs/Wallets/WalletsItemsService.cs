using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class WalletsItemsService : WalletsItemsServiceBase
{
    public WalletsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
