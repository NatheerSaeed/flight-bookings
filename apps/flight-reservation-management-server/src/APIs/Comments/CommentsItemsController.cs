using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class CommentsItemsController : CommentsItemsControllerBase
{
    public CommentsItemsController(ICommentsItemsService service)
        : base(service) { }
}
