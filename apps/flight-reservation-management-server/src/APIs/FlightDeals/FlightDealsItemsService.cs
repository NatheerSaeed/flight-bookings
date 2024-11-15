using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class FlightDealsItemsService : FlightDealsItemsServiceBase
{
    public FlightDealsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
