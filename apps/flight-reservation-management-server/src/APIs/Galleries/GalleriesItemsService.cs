using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class GalleriesItemsService : GalleriesItemsServiceBase
{
    public GalleriesItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
