using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class VisaApplicationsItemsController : VisaApplicationsItemsControllerBase
{
    public VisaApplicationsItemsController(IVisaApplicationsItemsService service)
        : base(service) { }
}
