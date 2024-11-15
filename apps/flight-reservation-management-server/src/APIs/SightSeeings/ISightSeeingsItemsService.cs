using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface ISightSeeingsItemsService
{
    /// <summary>
    /// Create one SightSeeings
    /// </summary>
    public Task<SightSeeings> CreateSightSeeings(SightSeeingsCreateInput sightseeings);

    /// <summary>
    /// Delete one SightSeeings
    /// </summary>
    public Task DeleteSightSeeings(SightSeeingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many SightSeeingsItems
    /// </summary>
    public Task<List<SightSeeings>> SightSeeingsItems(SightSeeingsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about SightSeeings records
    /// </summary>
    public Task<MetadataDto> SightSeeingsItemsMeta(SightSeeingsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one SightSeeings
    /// </summary>
    public Task<SightSeeings> SightSeeings(SightSeeingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one SightSeeings
    /// </summary>
    public Task UpdateSightSeeings(
        SightSeeingsWhereUniqueInput uniqueId,
        SightSeeingsUpdateInput updateDto
    );

    /// <summary>
    /// Get a attraction_ record for SightSeeings
    /// </summary>
    public Task<Attractions> GetAttraction(SightSeeingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a package_ record for SightSeeings
    /// </summary>
    public Task<Packages> GetPackageField(SightSeeingsWhereUniqueInput uniqueId);
}
