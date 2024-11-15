using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPackageAttractionsItemsService
{
    /// <summary>
    /// Create one PackageAttractions
    /// </summary>
    public Task<PackageAttractions> CreatePackageAttractions(
        PackageAttractionsCreateInput packageattractions
    );

    /// <summary>
    /// Delete one PackageAttractions
    /// </summary>
    public Task DeletePackageAttractions(PackageAttractionsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PackageAttractionsItems
    /// </summary>
    public Task<List<PackageAttractions>> PackageAttractionsItems(
        PackageAttractionsFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about PackageAttractions records
    /// </summary>
    public Task<MetadataDto> PackageAttractionsItemsMeta(
        PackageAttractionsFindManyArgs findManyArgs
    );

    /// <summary>
    /// Get one PackageAttractions
    /// </summary>
    public Task<PackageAttractions> PackageAttractions(PackageAttractionsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PackageAttractions
    /// </summary>
    public Task UpdatePackageAttractions(
        PackageAttractionsWhereUniqueInput uniqueId,
        PackageAttractionsUpdateInput updateDto
    );
}
