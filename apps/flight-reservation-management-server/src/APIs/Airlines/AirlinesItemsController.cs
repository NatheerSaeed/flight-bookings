using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class AirlinesItemsController : AirlinesItemsControllerBase
{
    public AirlinesItemsController(IAirlinesItemsService service)
        : base(service) { }
}
