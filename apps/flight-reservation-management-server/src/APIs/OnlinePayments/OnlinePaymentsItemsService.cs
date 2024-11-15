using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class OnlinePaymentsItemsService : OnlinePaymentsItemsServiceBase
{
    public OnlinePaymentsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
