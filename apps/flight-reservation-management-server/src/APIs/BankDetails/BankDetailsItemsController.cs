using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class BankDetailsItemsController : BankDetailsItemsControllerBase
{
    public BankDetailsItemsController(IBankDetailsItemsService service)
        : base(service) { }
}
