using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class WalletsItemsController : WalletsItemsControllerBase
{
    public WalletsItemsController(IWalletsItemsService service)
        : base(service) { }
}
