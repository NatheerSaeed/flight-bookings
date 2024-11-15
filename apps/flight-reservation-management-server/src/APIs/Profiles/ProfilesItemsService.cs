using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class ProfilesItemsService : ProfilesItemsServiceBase
{
    public ProfilesItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
