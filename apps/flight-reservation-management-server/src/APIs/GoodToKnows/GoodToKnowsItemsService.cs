using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class GoodToKnowsItemsService : GoodToKnowsItemsServiceBase
{
    public GoodToKnowsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
