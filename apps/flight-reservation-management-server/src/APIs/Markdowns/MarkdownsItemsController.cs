using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class MarkdownsItemsController : MarkdownsItemsControllerBase
{
    public MarkdownsItemsController(IMarkdownsItemsService service)
        : base(service) { }
}
