using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class MarkupsItemsService : MarkupsItemsServiceBase
{
    public MarkupsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
