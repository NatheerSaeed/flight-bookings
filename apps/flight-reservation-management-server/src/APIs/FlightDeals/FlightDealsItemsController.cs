using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class FlightDealsItemsController : FlightDealsItemsControllerBase
{
    public FlightDealsItemsController(IFlightDealsItemsService service)
        : base(service) { }
}
