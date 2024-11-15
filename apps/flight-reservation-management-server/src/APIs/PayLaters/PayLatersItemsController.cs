using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class PayLatersItemsController : PayLatersItemsControllerBase
{
    public PayLatersItemsController(IPayLatersItemsService service)
        : base(service) { }
}
