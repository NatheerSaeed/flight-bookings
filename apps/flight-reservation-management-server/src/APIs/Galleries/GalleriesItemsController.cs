using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class GalleriesItemsController : GalleriesItemsControllerBase
{
    public GalleriesItemsController(IGalleriesItemsService service)
        : base(service) { }
}
