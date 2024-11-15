using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IAttractionsItemsService
{
    /// <summary>
    /// Create one Attractions
    /// </summary>
    public Task<Attractions> CreateAttractions(AttractionsCreateInput attractions);

    /// <summary>
    /// Delete one Attractions
    /// </summary>
    public Task DeleteAttractions(AttractionsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many AttractionsItems
    /// </summary>
    public Task<List<Attractions>> AttractionsItems(AttractionsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Attractions records
    /// </summary>
    public Task<MetadataDto> AttractionsItemsMeta(AttractionsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Attractions
    /// </summary>
    public Task<Attractions> Attractions(AttractionsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Attractions
    /// </summary>
    public Task UpdateAttractions(
        AttractionsWhereUniqueInput uniqueId,
        AttractionsUpdateInput updateDto
    );

    /// <summary>
    /// Get a package_ record for Attractions
    /// </summary>
    public Task<Packages> GetPackageField(AttractionsWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple SightSeeingsItems records to Attractions
    /// </summary>
    public Task ConnectSightSeeingsItems(
        AttractionsWhereUniqueInput uniqueId,
        SightSeeingsWhereUniqueInput[] sightSeeingsId
    );

    /// <summary>
    /// Disconnect multiple SightSeeingsItems records from Attractions
    /// </summary>
    public Task DisconnectSightSeeingsItems(
        AttractionsWhereUniqueInput uniqueId,
        SightSeeingsWhereUniqueInput[] sightSeeingsId
    );

    /// <summary>
    /// Find multiple SightSeeingsItems records for Attractions
    /// </summary>
    public Task<List<SightSeeings>> FindSightSeeingsItems(
        AttractionsWhereUniqueInput uniqueId,
        SightSeeingsFindManyArgs SightSeeingsFindManyArgs
    );

    /// <summary>
    /// Update multiple SightSeeingsItems records for Attractions
    /// </summary>
    public Task UpdateSightSeeingsItems(
        AttractionsWhereUniqueInput uniqueId,
        SightSeeingsWhereUniqueInput[] sightSeeingsId
    );
}
