using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class PayLatersItemsService : PayLatersItemsServiceBase
{
    public PayLatersItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
