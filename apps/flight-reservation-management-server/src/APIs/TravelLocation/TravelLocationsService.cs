using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class TravelLocationsService : TravelLocationsServiceBase
{
    public TravelLocationsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
