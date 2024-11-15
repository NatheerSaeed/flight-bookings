using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPackageHotelsItemsService
{
    /// <summary>
    /// Create one PackageHotels
    /// </summary>
    public Task<PackageHotels> CreatePackageHotels(PackageHotelsCreateInput packagehotels);

    /// <summary>
    /// Delete one PackageHotels
    /// </summary>
    public Task DeletePackageHotels(PackageHotelsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PackageHotelsItems
    /// </summary>
    public Task<List<PackageHotels>> PackageHotelsItems(PackageHotelsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about PackageHotels records
    /// </summary>
    public Task<MetadataDto> PackageHotelsItemsMeta(PackageHotelsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PackageHotels
    /// </summary>
    public Task<PackageHotels> PackageHotels(PackageHotelsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PackageHotels
    /// </summary>
    public Task UpdatePackageHotels(
        PackageHotelsWhereUniqueInput uniqueId,
        PackageHotelsUpdateInput updateDto
    );

    /// <summary>
    /// Get a package_ record for PackageHotels
    /// </summary>
    public Task<Packages> GetPackageField(PackageHotelsWhereUniqueInput uniqueId);
}
