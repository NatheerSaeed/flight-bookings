using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class VouchersItemsController : VouchersItemsControllerBase
{
    public VouchersItemsController(IVouchersItemsService service)
        : base(service) { }
}
