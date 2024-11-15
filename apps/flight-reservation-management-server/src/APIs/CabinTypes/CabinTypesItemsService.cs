using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class CabinTypesItemsService : CabinTypesItemsServiceBase
{
    public CabinTypesItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
