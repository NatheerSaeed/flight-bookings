using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[ApiController()]
public class PackageCategoriesItemsController : PackageCategoriesItemsControllerBase
{
    public PackageCategoriesItemsController(IPackageCategoriesItemsService service)
        : base(service) { }
}
