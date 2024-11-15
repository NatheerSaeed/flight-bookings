using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class OnlinePaymentsItemsController : OnlinePaymentsItemsControllerBase
{
    public OnlinePaymentsItemsController(IOnlinePaymentsItemsService service)
        : base(service) { }
}
