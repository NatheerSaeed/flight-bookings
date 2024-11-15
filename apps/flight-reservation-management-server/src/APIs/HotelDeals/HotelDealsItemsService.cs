using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class HotelDealsItemsService : HotelDealsItemsServiceBase
{
    public HotelDealsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
