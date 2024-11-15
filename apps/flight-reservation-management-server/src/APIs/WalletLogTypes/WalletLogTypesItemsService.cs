using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class WalletLogTypesItemsService : WalletLogTypesItemsServiceBase
{
    public WalletLogTypesItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
