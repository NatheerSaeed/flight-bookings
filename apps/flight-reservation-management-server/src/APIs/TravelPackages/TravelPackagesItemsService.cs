using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class TravelPackagesItemsService : TravelPackagesItemsServiceBase
{
    public TravelPackagesItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
