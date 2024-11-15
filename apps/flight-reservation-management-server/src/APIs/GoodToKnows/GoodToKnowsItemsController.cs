using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class GoodToKnowsItemsController : GoodToKnowsItemsControllerBase
{
    public GoodToKnowsItemsController(IGoodToKnowsItemsService service)
        : base(service) { }
}
