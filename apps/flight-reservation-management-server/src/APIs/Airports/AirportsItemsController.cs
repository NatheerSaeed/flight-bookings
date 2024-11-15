using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class AirportsItemsController : AirportsItemsControllerBase
{
    public AirportsItemsController(IAirportsItemsService service)
        : base(service) { }
}
