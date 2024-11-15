using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class PackageBookingsItemsController : PackageBookingsItemsControllerBase
{
    public PackageBookingsItemsController(IPackageBookingsItemsService service)
        : base(service) { }
}
