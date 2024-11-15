using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IGoodToKnowsItemsService
{
    /// <summary>
    /// Create one GoodToKnows
    /// </summary>
    public Task<GoodToKnows> CreateGoodToKnows(GoodToKnowsCreateInput goodtoknows);

    /// <summary>
    /// Delete one GoodToKnows
    /// </summary>
    public Task DeleteGoodToKnows(GoodToKnowsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many GoodToKnowsItems
    /// </summary>
    public Task<List<GoodToKnows>> GoodToKnowsItems(GoodToKnowsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about GoodToKnows records
    /// </summary>
    public Task<MetadataDto> GoodToKnowsItemsMeta(GoodToKnowsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one GoodToKnows
    /// </summary>
    public Task<GoodToKnows> GoodToKnows(GoodToKnowsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one GoodToKnows
    /// </summary>
    public Task UpdateGoodToKnows(
        GoodToKnowsWhereUniqueInput uniqueId,
        GoodToKnowsUpdateInput updateDto
    );

    /// <summary>
    /// Get a package_ record for GoodToKnows
    /// </summary>
    public Task<Packages> GetPackageField(GoodToKnowsWhereUniqueInput uniqueId);
}
