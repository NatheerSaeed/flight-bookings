using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class AirportsItemsService : AirportsItemsServiceBase
{
    public AirportsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
