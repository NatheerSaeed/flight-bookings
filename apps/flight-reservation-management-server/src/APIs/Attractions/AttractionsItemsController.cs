using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class AttractionsItemsController : AttractionsItemsControllerBase
{
    public AttractionsItemsController(IAttractionsItemsService service)
        : base(service) { }
}
