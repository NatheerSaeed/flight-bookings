using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IAgencyProfilesService
{
    /// <summary>
    /// Create one AgencyProfiles
    /// </summary>
    public Task<AgencyProfiles> CreateAgencyProfile(AgencyProfileCreateInput agencyprofiles);

    /// <summary>
    /// Delete one AgencyProfiles
    /// </summary>
    public Task DeleteAgencyProfile(AgencyProfilesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many AgencyProfilesItems
    /// </summary>
    public Task<List<AgencyProfiles>> AgencyProfilesSearchAsync(
        AgencyProfileFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about AgencyProfiles records
    /// </summary>
    public Task<MetadataDto> AgencyProfilesItemsMeta(AgencyProfileFindManyArgs findManyArgs);

    /// <summary>
    /// Get one AgencyProfiles
    /// </summary>
    public Task<AgencyProfiles> AgencyProfiles(AgencyProfilesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one AgencyProfiles
    /// </summary>
    public Task UpdateAgencyProfile(
        AgencyProfilesWhereUniqueInput uniqueId,
        AgencyProfileUpdateInput updateDto
    );

    /// <summary>
    /// Get a user_ record for AgencyProfiles
    /// </summary>
    public Task<User> GetUser(AgencyProfilesWhereUniqueInput uniqueId);
}
