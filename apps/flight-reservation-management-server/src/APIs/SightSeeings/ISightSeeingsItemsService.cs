using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface ISightSeeingsService
{
    /// <summary>
    /// Create one SightSeeings
    /// </summary>
    public Task<SightSeeings> CreateSightSeeing(SightSeeingCreateInput sightseeings);

    /// <summary>
    /// Delete one SightSeeings
    /// </summary>
    public Task DeleteSightSeeing(SightSeeingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many SightSeeingsItems
    /// </summary>
    public Task<List<SightSeeings>> SightSeeingsItems(SightSeeingFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about SightSeeings records
    /// </summary>
    public Task<MetadataDto> SightSeeingsItemsMeta(SightSeeingFindManyArgs findManyArgs);

    /// <summary>
    /// Get one SightSeeings
    /// </summary>
    public Task<SightSeeings> SightSeeings(SightSeeingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one SightSeeings
    /// </summary>
    public Task UpdateSightSeeing(
        SightSeeingsWhereUniqueInput uniqueId,
        SightSeeingUpdateInput updateDto
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
