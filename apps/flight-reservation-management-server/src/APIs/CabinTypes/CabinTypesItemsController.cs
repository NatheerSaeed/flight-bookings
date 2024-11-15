using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class CabinTypesItemsController : CabinTypesItemsControllerBase
{
    public CabinTypesItemsController(ICabinTypesItemsService service)
        : base(service) { }
}
