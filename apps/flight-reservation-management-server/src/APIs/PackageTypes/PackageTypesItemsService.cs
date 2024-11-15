using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class PackageTypesItemsService : PackageTypesItemsServiceBase
{
    public PackageTypesItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
