using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface ICarBookingsItemsService
{
    /// <summary>
    /// Create one CarBookings
    /// </summary>
    public Task<CarBookings> CreateCarBookings(CarBookingsCreateInput carbookings);

    /// <summary>
    /// Delete one CarBookings
    /// </summary>
    public Task DeleteCarBookings(CarBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many CarBookingsItems
    /// </summary>
    public Task<List<CarBookings>> CarBookingsItems(CarBookingsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about CarBookings records
    /// </summary>
    public Task<MetadataDto> CarBookingsItemsMeta(CarBookingsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one CarBookings
    /// </summary>
    public Task<CarBookings> CarBookings(CarBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one CarBookings
    /// </summary>
    public Task UpdateCarBookings(
        CarBookingsWhereUniqueInput uniqueId,
        CarBookingsUpdateInput updateDto
    );

    /// <summary>
    /// Get a user_ record for CarBookings
    /// </summary>
    public Task<User> GetUser(CarBookingsWhereUniqueInput uniqueId);
}
