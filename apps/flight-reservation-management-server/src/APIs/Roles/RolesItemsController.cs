using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class RolesItemsController : RolesItemsControllerBase
{
    public RolesItemsController(IRolesItemsService service)
        : base(service) { }
}
