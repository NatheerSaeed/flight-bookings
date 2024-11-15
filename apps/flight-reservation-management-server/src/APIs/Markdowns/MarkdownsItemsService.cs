using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class MarkdownsItemsService : MarkdownsItemsServiceBase
{
    public MarkdownsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
