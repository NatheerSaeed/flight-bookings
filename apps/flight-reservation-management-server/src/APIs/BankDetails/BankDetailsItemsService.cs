using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class BankDetailsItemsService : BankDetailsItemsServiceBase
{
    public BankDetailsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
