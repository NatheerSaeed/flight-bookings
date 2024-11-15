using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IGalleriesService
{
    /// <summary>
    /// Create one Galleries
    /// </summary>
    public Task<Galleries> CreateGalleries(GallerieCreateInput galleries);

    /// <summary>
    /// Delete one Galleries
    /// </summary>
    public Task DeleteGalleries(GalleriesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many GalleriesItems
    /// </summary>
    public Task<List<Galleries>> GalleriesItems(GallerieFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Galleries records
    /// </summary>
    public Task<MetadataDto> GalleriesItemsMeta(GallerieFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Galleries
    /// </summary>
    public Task<Galleries> Galleries(GalleriesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Galleries
    /// </summary>
    public Task UpdateGalleries(GalleriesWhereUniqueInput uniqueId, GallerieUpdateInput updateDto);

    /// <summary>
    /// Get a package_ record for Galleries
    /// </summary>
    public Task<Packages> GetPackageField(GalleriesWhereUniqueInput uniqueId);
}
