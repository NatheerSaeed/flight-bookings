using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class BanksItemsController : BanksItemsControllerBase
{
    public BanksItemsController(IBanksItemsService service)
        : base(service) { }
}
