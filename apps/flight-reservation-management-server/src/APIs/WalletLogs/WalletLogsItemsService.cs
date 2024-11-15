using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class WalletLogsItemsService : WalletLogsItemsServiceBase
{
    public WalletLogsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
