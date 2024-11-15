using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPackageAttractionsService
{
    /// <summary>
    /// Create one PackageAttractions
    /// </summary>
    public Task<PackageAttractions> CreatePackageAttraction(
        PackageAttractionCreateInput packageattractions
    );

    /// <summary>
    /// Delete one PackageAttractions
    /// </summary>
    public Task DeletePackageAttraction(PackageAttractionsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PackageAttractionsItems
    /// </summary>
    public Task<List<PackageAttractions>> PackageAttractionsSearchAsync(
        PackageAttractionFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about PackageAttractions records
    /// </summary>
    public Task<MetadataDto> PackageAttractionsItemsMeta(
        PackageAttractionFindManyArgs findManyArgs
    );

    /// <summary>
    /// Get one PackageAttractions
    /// </summary>
    public Task<PackageAttractions> PackageAttractions(PackageAttractionsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PackageAttractions
    /// </summary>
    public Task UpdatePackageAttraction(
        PackageAttractionsWhereUniqueInput uniqueId,
        PackageAttractionUpdateInput updateDto
    );

    /// <summary>
    /// Get a package_ record for PackageAttractions
    /// </summary>
    public Task<Packages> GetPackageField(PackageAttractionsWhereUniqueInput uniqueId);
}
