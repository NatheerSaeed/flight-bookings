using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class VatsItemsController : VatsItemsControllerBase
{
    public VatsItemsController(IVatsItemsService service)
        : base(service) { }
}
