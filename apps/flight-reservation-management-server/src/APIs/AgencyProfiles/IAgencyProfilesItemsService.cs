using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IAgencyProfilesItemsService
{
    /// <summary>
    /// Create one AgencyProfiles
    /// </summary>
    public Task<AgencyProfiles> CreateAgencyProfiles(AgencyProfilesCreateInput agencyprofiles);

    /// <summary>
    /// Delete one AgencyProfiles
    /// </summary>
    public Task DeleteAgencyProfiles(AgencyProfilesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many AgencyProfilesItems
    /// </summary>
    public Task<List<AgencyProfiles>> AgencyProfilesItems(AgencyProfilesFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about AgencyProfiles records
    /// </summary>
    public Task<MetadataDto> AgencyProfilesItemsMeta(AgencyProfilesFindManyArgs findManyArgs);

    /// <summary>
    /// Get one AgencyProfiles
    /// </summary>
    public Task<AgencyProfiles> AgencyProfiles(AgencyProfilesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one AgencyProfiles
    /// </summary>
    public Task UpdateAgencyProfiles(
        AgencyProfilesWhereUniqueInput uniqueId,
        AgencyProfilesUpdateInput updateDto
    );

    /// <summary>
    /// Get a user_ record for AgencyProfiles
    /// </summary>
    public Task<User> GetUser(AgencyProfilesWhereUniqueInput uniqueId);
}
