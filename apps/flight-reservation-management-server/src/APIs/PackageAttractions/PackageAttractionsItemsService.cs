using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class PackageAttractionsItemsService : PackageAttractionsItemsServiceBase
{
    public PackageAttractionsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
