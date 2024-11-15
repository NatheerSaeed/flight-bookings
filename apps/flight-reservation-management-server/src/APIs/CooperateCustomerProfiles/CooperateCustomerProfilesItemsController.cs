using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class CooperateCustomerProfilesItemsController : CooperateCustomerProfilesItemsControllerBase
{
    public CooperateCustomerProfilesItemsController(ICooperateCustomerProfilesItemsService service)
        : base(service) { }
}
