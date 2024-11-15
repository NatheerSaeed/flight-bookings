using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class PackagesItemsService : PackagesItemsServiceBase
{
    public PackagesItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
