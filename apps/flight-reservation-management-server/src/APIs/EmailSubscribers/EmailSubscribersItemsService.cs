using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class EmailSubscribersItemsService : EmailSubscribersItemsServiceBase
{
    public EmailSubscribersItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
