using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class ProfilesItemsController : ProfilesItemsControllerBase
{
    public ProfilesItemsController(IProfilesItemsService service)
        : base(service) { }
}
