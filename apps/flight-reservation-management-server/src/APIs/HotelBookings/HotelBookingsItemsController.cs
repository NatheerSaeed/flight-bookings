using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class HotelBookingsItemsController : HotelBookingsItemsControllerBase
{
    public HotelBookingsItemsController(IHotelBookingsItemsService service)
        : base(service) { }
}
