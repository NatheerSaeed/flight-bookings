using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class WalletLogTypesItemsController : WalletLogTypesItemsControllerBase
{
    public WalletLogTypesItemsController(IWalletLogTypesItemsService service)
        : base(service) { }
}
