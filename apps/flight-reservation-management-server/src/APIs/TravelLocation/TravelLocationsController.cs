using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class TravelLocationsController : TravelLocationsControllerBase
{
    public TravelLocationsController(ITravelLocationsService service)
        : base(service) { }
}
