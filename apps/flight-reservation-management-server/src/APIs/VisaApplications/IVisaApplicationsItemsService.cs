using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IVisaApplicationsService
{
    /// <summary>
    /// Create one VisaApplications
    /// </summary>
    public Task<VisaApplications> CreateVisaApplication(
        VisaApplicationCreateInput visaapplications
    );

    /// <summary>
    /// Delete one VisaApplications
    /// </summary>
    public Task DeleteVisaApplication(VisaApplicationsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many VisaApplicationsItems
    /// </summary>
    public Task<List<VisaApplications>> VisaApplicationsItems(
        VisaApplicationFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about VisaApplications records
    /// </summary>
    public Task<MetadataDto> VisaApplicationsItemsMeta(VisaApplicationFindManyArgs findManyArgs);

    /// <summary>
    /// Get one VisaApplications
    /// </summary>
    public Task<VisaApplications> VisaApplications(VisaApplicationsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one VisaApplications
    /// </summary>
    public Task UpdateVisaApplication(
        VisaApplicationsWhereUniqueInput uniqueId,
        VisaApplicationUpdateInput updateDto
    );
}
