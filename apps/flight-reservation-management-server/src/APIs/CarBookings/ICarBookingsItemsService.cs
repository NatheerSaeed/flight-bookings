using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface ICarBookingsService
{
    /// <summary>
    /// Create one CarBookings
    /// </summary>
    public Task<CarBookings> CreateCarBooking(CarBookingCreateInput carbookings);

    /// <summary>
    /// Delete one CarBookings
    /// </summary>
    public Task DeleteCarBooking(CarBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many CarBookingsItems
    /// </summary>
    public Task<List<CarBookings>> CarBookingsItems(CarBookingFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about CarBookings records
    /// </summary>
    public Task<MetadataDto> CarBookingsItemsMeta(CarBookingFindManyArgs findManyArgs);

    /// <summary>
    /// Get one CarBookings
    /// </summary>
    public Task<CarBookings> CarBookings(CarBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one CarBookings
    /// </summary>
    public Task UpdateCarBooking(
        CarBookingsWhereUniqueInput uniqueId,
        CarBookingUpdateInput updateDto
    );

    /// <summary>
    /// Get a user_ record for CarBookings
    /// </summary>
    public Task<User> GetUser(CarBookingsWhereUniqueInput uniqueId);
}
