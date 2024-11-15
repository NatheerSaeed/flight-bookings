using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class BanksItemsService : BanksItemsServiceBase
{
    public BanksItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
