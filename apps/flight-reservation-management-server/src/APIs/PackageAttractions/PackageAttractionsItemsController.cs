using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class PackageAttractionsItemsController : PackageAttractionsItemsControllerBase
{
    public PackageAttractionsItemsController(IPackageAttractionsItemsService service)
        : base(service) { }
}
