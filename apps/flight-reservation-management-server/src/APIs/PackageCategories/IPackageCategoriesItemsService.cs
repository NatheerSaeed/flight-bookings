using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPackageCategoriesItemsService
{
    /// <summary>
    /// Create one PackageCategories
    /// </summary>
    public Task<PackageCategories> CreatePackageCategories(
        PackageCategoriesCreateInput packagecategories
    );

    /// <summary>
    /// Delete one PackageCategories
    /// </summary>
    public Task DeletePackageCategories(PackageCategoriesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PackageCategoriesItems
    /// </summary>
    public Task<List<PackageCategories>> PackageCategoriesItems(
        PackageCategoriesFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about PackageCategories records
    /// </summary>
    public Task<MetadataDto> PackageCategoriesItemsMeta(PackageCategoriesFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PackageCategories
    /// </summary>
    public Task<PackageCategories> PackageCategories(PackageCategoriesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PackageCategories
    /// </summary>
    public Task UpdatePackageCategories(
        PackageCategoriesWhereUniqueInput uniqueId,
        PackageCategoriesUpdateInput updateDto
    );
}
