using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class AirlinesItemsService : AirlinesItemsServiceBase
{
    public AirlinesItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
