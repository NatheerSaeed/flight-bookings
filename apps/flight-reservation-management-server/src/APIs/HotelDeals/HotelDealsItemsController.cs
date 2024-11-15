using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class HotelDealsItemsController : HotelDealsItemsControllerBase
{
    public HotelDealsItemsController(IHotelDealsItemsService service)
        : base(service) { }
}
