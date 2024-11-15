using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface ITitlesService
{
    /// <summary>
    /// Create one Titles
    /// </summary>
    public Task<Titles> CreateTitles(TitleCreateInput titles);

    /// <summary>
    /// Delete one Titles
    /// </summary>
    public Task DeleteTitles(TitlesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many TitlesItems
    /// </summary>
    public Task<List<Titles>> TitlesItems(TitleFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Titles records
    /// </summary>
    public Task<MetadataDto> TitlesItemsMeta(TitleFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Titles
    /// </summary>
    public Task<Titles> Titles(TitlesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Titles
    /// </summary>
    public Task UpdateTitles(TitlesWhereUniqueInput uniqueId, TitleUpdateInput updateDto);

    /// <summary>
    /// Connect multiple ProfilesItems records to Titles
    /// </summary>
    public Task ConnectProfilesItems(
        TitlesWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] profilesId
    );

    /// <summary>
    /// Disconnect multiple ProfilesItems records from Titles
    /// </summary>
    public Task DisconnectProfilesItems(
        TitlesWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] profilesId
    );

    /// <summary>
    /// Find multiple ProfilesItems records for Titles
    /// </summary>
    public Task<List<Profiles>> FindProfilesItems(
        TitlesWhereUniqueInput uniqueId,
        ProfileFindManyArgs ProfileFindManyArgs
    );

    /// <summary>
    /// Update multiple ProfilesItems records for Titles
    /// </summary>
    public Task UpdateProfilesItems(
        TitlesWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] profilesId
    );
}
