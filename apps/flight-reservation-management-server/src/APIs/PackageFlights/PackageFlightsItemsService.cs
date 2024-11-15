using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class PackageFlightsItemsService : PackageFlightsItemsServiceBase
{
    public PackageFlightsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
