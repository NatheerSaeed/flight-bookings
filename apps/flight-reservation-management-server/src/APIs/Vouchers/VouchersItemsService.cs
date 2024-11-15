using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class VouchersItemsService : VouchersItemsServiceBase
{
    public VouchersItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
