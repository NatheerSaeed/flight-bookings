using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class PasswordResetsItemsController : PasswordResetsItemsControllerBase
{
    public PasswordResetsItemsController(IPasswordResetsItemsService service)
        : base(service) { }
}
