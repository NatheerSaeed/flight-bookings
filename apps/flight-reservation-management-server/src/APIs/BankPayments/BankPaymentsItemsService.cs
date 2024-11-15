using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class BankPaymentsItemsService : BankPaymentsItemsServiceBase
{
    public BankPaymentsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
