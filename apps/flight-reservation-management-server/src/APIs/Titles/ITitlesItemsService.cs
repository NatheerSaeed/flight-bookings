using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface ITitlesItemsService
{
    /// <summary>
    /// Create one Titles
    /// </summary>
    public Task<Titles> CreateTitles(TitlesCreateInput titles);

    /// <summary>
    /// Delete one Titles
    /// </summary>
    public Task DeleteTitles(TitlesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many TitlesItems
    /// </summary>
    public Task<List<Titles>> TitlesItems(TitlesFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Titles records
    /// </summary>
    public Task<MetadataDto> TitlesItemsMeta(TitlesFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Titles
    /// </summary>
    public Task<Titles> Titles(TitlesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Titles
    /// </summary>
    public Task UpdateTitles(TitlesWhereUniqueInput uniqueId, TitlesUpdateInput updateDto);

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
        ProfilesFindManyArgs ProfilesFindManyArgs
    );

    /// <summary>
    /// Update multiple ProfilesItems records for Titles
    /// </summary>
    public Task UpdateProfilesItems(
        TitlesWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] profilesId
    );
}
