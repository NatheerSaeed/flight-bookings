using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class TitlesItemsService : TitlesItemsServiceBase
{
    public TitlesItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
