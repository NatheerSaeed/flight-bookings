using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class PackagesService : PackagesServiceBase
{
    public PackagesService(FlightReservationManagementDbContext context)
        : base(context) { }
}
