using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class HotelsItemsController : HotelsItemsControllerBase
{
    public HotelsItemsController(IHotelsItemsService service)
        : base(service) { }
}
