using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class HotelBookingsItemsService : HotelBookingsItemsServiceBase
{
    public HotelBookingsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
