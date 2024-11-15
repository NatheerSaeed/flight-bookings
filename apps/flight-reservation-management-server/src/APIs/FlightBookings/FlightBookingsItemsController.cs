using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class FlightBookingsItemsController : FlightBookingsItemsControllerBase
{
    public FlightBookingsItemsController(IFlightBookingsItemsService service)
        : base(service) { }
}
