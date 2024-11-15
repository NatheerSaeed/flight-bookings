using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class RolesItemsService : RolesItemsServiceBase
{
    public RolesItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
