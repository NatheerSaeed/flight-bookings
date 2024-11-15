using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class PasswordResetsController : PasswordResetsControllerBase
{
    public PasswordResetsController(IPasswordResetsService service)
        : base(service) { }
}
