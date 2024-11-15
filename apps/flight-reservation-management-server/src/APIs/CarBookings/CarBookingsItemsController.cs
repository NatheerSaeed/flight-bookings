using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class CarBookingsItemsController : CarBookingsItemsControllerBase
{
    public CarBookingsItemsController(ICarBookingsItemsService service)
        : base(service) { }
}
