using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class AgencyProfilesItemsController : AgencyProfilesItemsControllerBase
{
    public AgencyProfilesItemsController(IAgencyProfilesItemsService service)
        : base(service) { }
}
