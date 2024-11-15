using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class CooperateCustomerProfilesItemsService : CooperateCustomerProfilesItemsServiceBase
{
    public CooperateCustomerProfilesItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
