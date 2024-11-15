using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class MarkupsItemsController : MarkupsItemsControllerBase
{
    public MarkupsItemsController(IMarkupsItemsService service)
        : base(service) { }
}
