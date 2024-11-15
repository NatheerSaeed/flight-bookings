using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IProfilesItemsService
{
    /// <summary>
    /// Create one Profiles
    /// </summary>
    public Task<Profiles> CreateProfiles(ProfilesCreateInput profiles);

    /// <summary>
    /// Delete one Profiles
    /// </summary>
    public Task DeleteProfiles(ProfilesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ProfilesItems
    /// </summary>
    public Task<List<Profiles>> ProfilesItems(ProfilesFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Profiles records
    /// </summary>
    public Task<MetadataDto> ProfilesItemsMeta(ProfilesFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Profiles
    /// </summary>
    public Task<Profiles> Profiles(ProfilesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Profiles
    /// </summary>
    public Task UpdateProfiles(ProfilesWhereUniqueInput uniqueId, ProfilesUpdateInput updateDto);

    /// <summary>
    /// Get a gender_ record for Profiles
    /// </summary>
    public Task<Genders> GetGender(ProfilesWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a title_ record for Profiles
    /// </summary>
    public Task<Titles> GetTitle(ProfilesWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a user_ record for Profiles
    /// </summary>
    public Task<User> GetUser(ProfilesWhereUniqueInput uniqueId);
}
