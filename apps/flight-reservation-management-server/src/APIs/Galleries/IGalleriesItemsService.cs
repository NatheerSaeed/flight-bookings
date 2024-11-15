using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IGalleriesItemsService
{
    /// <summary>
    /// Create one Galleries
    /// </summary>
    public Task<Galleries> CreateGalleries(GalleriesCreateInput galleries);

    /// <summary>
    /// Delete one Galleries
    /// </summary>
    public Task DeleteGalleries(GalleriesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many GalleriesItems
    /// </summary>
    public Task<List<Galleries>> GalleriesItems(GalleriesFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Galleries records
    /// </summary>
    public Task<MetadataDto> GalleriesItemsMeta(GalleriesFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Galleries
    /// </summary>
    public Task<Galleries> Galleries(GalleriesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Galleries
    /// </summary>
    public Task UpdateGalleries(GalleriesWhereUniqueInput uniqueId, GalleriesUpdateInput updateDto);

    /// <summary>
    /// Get a package_ record for Galleries
    /// </summary>
    public Task<Packages> GetPackageField(GalleriesWhereUniqueInput uniqueId);
}
