using FlightReservationManagement.Infrastructure;

namespace FlightReservationManagement.APIs;

public class VisaApplicationsItemsService : VisaApplicationsItemsServiceBase
{
    public VisaApplicationsItemsService(FlightReservationManagementDbContext context)
        : base(context) { }
}
