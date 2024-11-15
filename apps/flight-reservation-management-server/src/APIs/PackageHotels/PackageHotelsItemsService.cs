using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class PackageHotelsItemsService : PackageHotelsItemsServiceBase
{
    public PackageHotelsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
