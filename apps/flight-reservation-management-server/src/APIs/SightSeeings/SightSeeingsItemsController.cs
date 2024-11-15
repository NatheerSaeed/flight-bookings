using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class SightSeeingsItemsController : SightSeeingsItemsControllerBase
{
    public SightSeeingsItemsController(ISightSeeingsItemsService service)
        : base(service) { }
}
