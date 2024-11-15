using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPackageBookingsService
{
    /// <summary>
    /// Create one PackageBookings
    /// </summary>
    public Task<PackageBookings> CreatePackageBookings(PackageBookingCreateInput packagebookings);

    /// <summary>
    /// Delete one PackageBookings
    /// </summary>
    public Task DeletePackageBookings(PackageBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PackageBookingsItems
    /// </summary>
    public Task<List<PackageBookings>> PackageBookingsItems(
        PackageBookingFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about PackageBookings records
    /// </summary>
    public Task<MetadataDto> PackageBookingsItemsMeta(PackageBookingFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PackageBookings
    /// </summary>
    public Task<PackageBookings> PackageBookings(PackageBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PackageBookings
    /// </summary>
    public Task UpdatePackageBookings(
        PackageBookingsWhereUniqueInput uniqueId,
        PackageBookingUpdateInput updateDto
    );

    /// <summary>
    /// Get a package_ record for PackageBookings
    /// </summary>
    public Task<Packages> GetPackageField(PackageBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a user_ record for PackageBookings
    /// </summary>
    public Task<User> GetUser(PackageBookingsWhereUniqueInput uniqueId);
}
