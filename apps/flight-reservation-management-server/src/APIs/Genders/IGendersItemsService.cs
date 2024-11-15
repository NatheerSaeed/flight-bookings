using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IGendersItemsService
{
    /// <summary>
    /// Create one Genders
    /// </summary>
    public Task<Genders> CreateGenders(GendersCreateInput genders);

    /// <summary>
    /// Delete one Genders
    /// </summary>
    public Task DeleteGenders(GendersWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many GendersItems
    /// </summary>
    public Task<List<Genders>> GendersItems(GendersFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Genders records
    /// </summary>
    public Task<MetadataDto> GendersItemsMeta(GendersFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Genders
    /// </summary>
    public Task<Genders> Genders(GendersWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Genders
    /// </summary>
    public Task UpdateGenders(GendersWhereUniqueInput uniqueId, GendersUpdateInput updateDto);

    /// <summary>
    /// Connect multiple ProfilesItems records to Genders
    /// </summary>
    public Task ConnectProfilesItems(
        GendersWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] profilesId
    );

    /// <summary>
    /// Disconnect multiple ProfilesItems records from Genders
    /// </summary>
    public Task DisconnectProfilesItems(
        GendersWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] profilesId
    );

    /// <summary>
    /// Find multiple ProfilesItems records for Genders
    /// </summary>
    public Task<List<Profiles>> FindProfilesItems(
        GendersWhereUniqueInput uniqueId,
        ProfilesFindManyArgs ProfilesFindManyArgs
    );

    /// <summary>
    /// Update multiple ProfilesItems records for Genders
    /// </summary>
    public Task UpdateProfilesItems(
        GendersWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] profilesId
    );
}
