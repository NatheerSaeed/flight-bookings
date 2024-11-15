using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IGoodToKnowsService
{
    /// <summary>
    /// Create one GoodToKnows
    /// </summary>
    public Task<GoodToKnows> CreateGoodToKnows(GoodToKnowCreateInput goodtoknows);

    /// <summary>
    /// Delete one GoodToKnows
    /// </summary>
    public Task DeleteGoodToKnows(GoodToKnowsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many GoodToKnowsItems
    /// </summary>
    public Task<List<GoodToKnows>> GoodToKnowsItems(GoodToKnowFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about GoodToKnows records
    /// </summary>
    public Task<MetadataDto> GoodToKnowsItemsMeta(GoodToKnowFindManyArgs findManyArgs);

    /// <summary>
    /// Get one GoodToKnows
    /// </summary>
    public Task<GoodToKnows> GoodToKnows(GoodToKnowsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one GoodToKnows
    /// </summary>
    public Task UpdateGoodToKnows(
        GoodToKnowsWhereUniqueInput uniqueId,
        GoodToKnowUpdateInput updateDto
    );

    /// <summary>
    /// Get a package_ record for GoodToKnows
    /// </summary>
    public Task<Packages> GetPackageField(GoodToKnowsWhereUniqueInput uniqueId);
}
