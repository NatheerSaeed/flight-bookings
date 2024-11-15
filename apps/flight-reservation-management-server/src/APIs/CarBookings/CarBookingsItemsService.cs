using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class CarBookingsItemsService : CarBookingsItemsServiceBase
{
    public CarBookingsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
