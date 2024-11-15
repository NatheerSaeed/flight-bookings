using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPackageBookingsItemsService
{
    /// <summary>
    /// Create one PackageBookings
    /// </summary>
    public Task<PackageBookings> CreatePackageBookings(PackageBookingsCreateInput packagebookings);

    /// <summary>
    /// Delete one PackageBookings
    /// </summary>
    public Task DeletePackageBookings(PackageBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PackageBookingsItems
    /// </summary>
    public Task<List<PackageBookings>> PackageBookingsItems(
        PackageBookingsFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about PackageBookings records
    /// </summary>
    public Task<MetadataDto> PackageBookingsItemsMeta(PackageBookingsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PackageBookings
    /// </summary>
    public Task<PackageBookings> PackageBookings(PackageBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PackageBookings
    /// </summary>
    public Task UpdatePackageBookings(
        PackageBookingsWhereUniqueInput uniqueId,
        PackageBookingsUpdateInput updateDto
    );
}
