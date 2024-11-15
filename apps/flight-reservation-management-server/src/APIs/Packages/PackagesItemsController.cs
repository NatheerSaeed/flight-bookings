using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class PackagesItemsController : PackagesItemsControllerBase
{
    public PackagesItemsController(IPackagesItemsService service)
        : base(service) { }
}
