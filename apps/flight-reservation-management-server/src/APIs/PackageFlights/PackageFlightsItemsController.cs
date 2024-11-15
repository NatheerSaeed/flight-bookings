using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class PackageFlightsItemsController : PackageFlightsItemsControllerBase
{
    public PackageFlightsItemsController(IPackageFlightsItemsService service)
        : base(service) { }
}
