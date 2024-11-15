using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class GendersItemsController : GendersItemsControllerBase
{
    public GendersItemsController(IGendersItemsService service)
        : base(service) { }
}
