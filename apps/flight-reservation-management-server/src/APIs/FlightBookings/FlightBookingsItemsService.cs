using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class FlightBookingsItemsService : FlightBookingsItemsServiceBase
{
    public FlightBookingsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
