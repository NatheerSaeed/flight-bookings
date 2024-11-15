using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class BankPaymentsItemsController : BankPaymentsItemsControllerBase
{
    public BankPaymentsItemsController(IBankPaymentsItemsService service)
        : base(service) { }
}
