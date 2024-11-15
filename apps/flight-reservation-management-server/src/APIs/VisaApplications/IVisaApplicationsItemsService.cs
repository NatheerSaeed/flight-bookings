using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IVisaApplicationsItemsService
{
    /// <summary>
    /// Create one VisaApplications
    /// </summary>
    public Task<VisaApplications> CreateVisaApplications(
        VisaApplicationsCreateInput visaapplications
    );

    /// <summary>
    /// Delete one VisaApplications
    /// </summary>
    public Task DeleteVisaApplications(VisaApplicationsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many VisaApplicationsItems
    /// </summary>
    public Task<List<VisaApplications>> VisaApplicationsItems(
        VisaApplicationsFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about VisaApplications records
    /// </summary>
    public Task<MetadataDto> VisaApplicationsItemsMeta(VisaApplicationsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one VisaApplications
    /// </summary>
    public Task<VisaApplications> VisaApplications(VisaApplicationsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one VisaApplications
    /// </summary>
    public Task UpdateVisaApplications(
        VisaApplicationsWhereUniqueInput uniqueId,
        VisaApplicationsUpdateInput updateDto
    );
}
