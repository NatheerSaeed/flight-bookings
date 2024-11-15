using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class PackagesController : PackagesControllerBase
{
    public PackagesController(IPackagesService service)
        : base(service) { }
}
