using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class AttractionsItemsService : AttractionsItemsServiceBase
{
    public AttractionsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
