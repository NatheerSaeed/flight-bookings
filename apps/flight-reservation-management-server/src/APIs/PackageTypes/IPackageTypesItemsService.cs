using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPackageTypesService
{
    /// <summary>
    /// Create one PackageTypes
    /// </summary>
    public Task<PackageTypes> CreatePackageTypes(PackageTypeCreateInput packagetypes);

    /// <summary>
    /// Delete one PackageTypes
    /// </summary>
    public Task DeletePackageTypes(PackageTypesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PackageTypesItems
    /// </summary>
    public Task<List<PackageTypes>> PackageTypesItems(PackageTypeFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about PackageTypes records
    /// </summary>
    public Task<MetadataDto> PackageTypesItemsMeta(PackageTypeFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PackageTypes
    /// </summary>
    public Task<PackageTypes> PackageTypes(PackageTypesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PackageTypes
    /// </summary>
    public Task UpdatePackageTypes(
        PackageTypesWhereUniqueInput uniqueId,
        PackageTypeUpdateInput updateDto
    );
}
