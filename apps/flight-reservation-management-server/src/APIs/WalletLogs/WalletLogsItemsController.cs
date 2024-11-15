using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class WalletLogsItemsController : WalletLogsItemsControllerBase
{
    public WalletLogsItemsController(IWalletLogsItemsService service)
        : base(service) { }
}
