using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class GendersItemsService : GendersItemsServiceBase
{
    public GendersItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
