using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class HotelsItemsService : HotelsItemsServiceBase
{
    public HotelsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
