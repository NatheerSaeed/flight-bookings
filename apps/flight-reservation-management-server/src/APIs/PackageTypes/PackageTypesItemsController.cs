using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class PackageTypesItemsController : PackageTypesItemsControllerBase
{
    public PackageTypesItemsController(IPackageTypesItemsService service)
        : base(service) { }
}
