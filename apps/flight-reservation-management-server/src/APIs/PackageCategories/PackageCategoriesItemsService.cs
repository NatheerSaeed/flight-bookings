using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class PackageCategoriesItemsService : PackageCategoriesItemsServiceBase
{
    public PackageCategoriesItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
