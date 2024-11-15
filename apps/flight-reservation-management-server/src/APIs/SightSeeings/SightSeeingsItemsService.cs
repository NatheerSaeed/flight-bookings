using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class SightSeeingsItemsService : SightSeeingsItemsServiceBase
{
    public SightSeeingsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
