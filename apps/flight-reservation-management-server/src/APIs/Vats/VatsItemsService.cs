using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class VatsItemsService : VatsItemsServiceBase
{
    public VatsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
