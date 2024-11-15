using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class CommentsItemsService : CommentsItemsServiceBase
{
    public CommentsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
