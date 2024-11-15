using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IProfilesService
{
    /// <summary>
    /// Create one Profiles
    /// </summary>
    public Task<Profiles> CreateProfile(ProfileCreateInput profiles);

    /// <summary>
    /// Delete one Profiles
    /// </summary>
    public Task DeleteProfile(ProfilesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ProfilesItems
    /// </summary>
    public Task<List<Profiles>> ProfilesItems(ProfileFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Profiles records
    /// </summary>
    public Task<MetadataDto> ProfilesItemsMeta(ProfileFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Profiles
    /// </summary>
    public Task<Profiles> Profiles(ProfilesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Profiles
    /// </summary>
    public Task UpdateProfile(ProfilesWhereUniqueInput uniqueId, ProfileUpdateInput updateDto);

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
