using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface ICooperateCustomerProfilesService
{
    /// <summary>
    /// Create one CooperateCustomerProfiles
    /// </summary>
    public Task<CooperateCustomerProfiles> CreateCooperateCustomerProfile(
        CooperateCustomerProfileCreateInput cooperatecustomerprofiles
    );

    /// <summary>
    /// Delete one CooperateCustomerProfiles
    /// </summary>
    public Task DeleteCooperateCustomerProfile(CooperateCustomerProfilesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many CooperateCustomerProfilesItems
    /// </summary>
    public Task<List<CooperateCustomerProfiles>> CooperateCustomerProfilesItems(
        CooperateCustomerProfileFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about CooperateCustomerProfiles records
    /// </summary>
    public Task<MetadataDto> CooperateCustomerProfilesItemsMeta(
        CooperateCustomerProfileFindManyArgs findManyArgs
    );

    /// <summary>
    /// Get one CooperateCustomerProfiles
    /// </summary>
    public Task<CooperateCustomerProfiles> CooperateCustomerProfiles(
        CooperateCustomerProfilesWhereUniqueInput uniqueId
    );

    /// <summary>
    /// Update one CooperateCustomerProfiles
    /// </summary>
    public Task UpdateCooperateCustomerProfile(
        CooperateCustomerProfilesWhereUniqueInput uniqueId,
        CooperateCustomerProfileUpdateInput updateDto
    );

    /// <summary>
    /// Get a user_ record for CooperateCustomerProfiles
    /// </summary>
    public Task<User> GetUser(CooperateCustomerProfilesWhereUniqueInput uniqueId);
}
