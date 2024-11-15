using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class PackageBookingsItemsService : PackageBookingsItemsServiceBase
{
    public PackageBookingsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
