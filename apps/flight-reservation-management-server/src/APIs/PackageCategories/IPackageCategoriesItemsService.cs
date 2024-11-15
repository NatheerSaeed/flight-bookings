using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPackageCategoriesService
{
    /// <summary>
    /// Create one PackageCategories
    /// </summary>
    public Task<PackageCategories> CreatePackageCategorie(
        PackageCategorieCreateInput packagecategories
    );

    /// <summary>
    /// Delete one PackageCategories
    /// </summary>
    public Task DeletePackageCategorie(PackageCategoriesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PackageCategoriesItems
    /// </summary>
    public Task<List<PackageCategories>> PackageCategoriesItems(
        PackageCategorieFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about PackageCategories records
    /// </summary>
    public Task<MetadataDto> PackageCategoriesItemsMeta(PackageCategorieFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PackageCategories
    /// </summary>
    public Task<PackageCategories> PackageCategories(PackageCategoriesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PackageCategories
    /// </summary>
    public Task UpdatePackageCategorie(
        PackageCategoriesWhereUniqueInput uniqueId,
        PackageCategorieUpdateInput updateDto
    );
}
