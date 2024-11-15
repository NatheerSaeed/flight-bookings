using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class EmailSubscribersItemsController : EmailSubscribersItemsControllerBase
{
    public EmailSubscribersItemsController(IEmailSubscribersItemsService service)
        : base(service) { }
}
