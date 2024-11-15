using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class PackageHotelsItemsController : PackageHotelsItemsControllerBase
{
    public PackageHotelsItemsController(IPackageHotelsItemsService service)
        : base(service) { }
}
