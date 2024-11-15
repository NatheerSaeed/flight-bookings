using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class TitlesItemsController : TitlesItemsControllerBase
{
    public TitlesItemsController(ITitlesItemsService service)
        : base(service) { }
}
