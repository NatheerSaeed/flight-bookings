using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class TravelPackagesItemsController : TravelPackagesItemsControllerBase
{
    public TravelPackagesItemsController(ITravelPackagesItemsService service)
        : base(service) { }
}
