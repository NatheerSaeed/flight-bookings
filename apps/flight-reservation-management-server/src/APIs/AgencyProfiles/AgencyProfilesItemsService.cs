using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class AgencyProfilesItemsService : AgencyProfilesItemsServiceBase
{
    public AgencyProfilesItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
