using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPackageHotelsService
{
    /// <summary>
    /// Create one PackageHotels
    /// </summary>
    public Task<PackageHotels> CreatePackageHotel(PackageHotelCreateInput packagehotels);

    /// <summary>
    /// Delete one PackageHotels
    /// </summary>
    public Task DeletePackageHotel(PackageHotelsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PackageHotelsItems
    /// </summary>
    public Task<List<PackageHotels>> PackageHotelsSearchAsync(
        PackageHotelFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about PackageHotels records
    /// </summary>
    public Task<MetadataDto> PackageHotelsItemsMeta(PackageHotelFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PackageHotels
    /// </summary>
    public Task<PackageHotels> PackageHotels(PackageHotelsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PackageHotels
    /// </summary>
    public Task UpdatePackageHotel(
        PackageHotelsWhereUniqueInput uniqueId,
        PackageHotelUpdateInput updateDto
    );

    /// <summary>
    /// Get a package_ record for PackageHotels
    /// </summary>
    public Task<Packages> GetPackageField(PackageHotelsWhereUniqueInput uniqueId);
}
