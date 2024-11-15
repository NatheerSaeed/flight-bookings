using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IHotelBookingsService
{
    /// <summary>
    /// Create one HotelBookings
    /// </summary>
    public Task<HotelBookings> CreateHotelBooking(HotelBookingCreateInput hotelbookings);

    /// <summary>
    /// Delete one HotelBookings
    /// </summary>
    public Task DeleteHotelBooking(HotelBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many HotelBookingsItems
    /// </summary>
    public Task<List<HotelBookings>> HotelBookingsSearchAsync(HotelBookingFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about HotelBookings records
    /// </summary>
    public Task<MetadataDto> HotelBookingsItemsMeta(HotelBookingFindManyArgs findManyArgs);

    /// <summary>
    /// Get one HotelBookings
    /// </summary>
    public Task<HotelBookings> HotelBookings(HotelBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one HotelBookings
    /// </summary>
    public Task UpdateHotelBooking(
        HotelBookingsWhereUniqueInput uniqueId,
        HotelBookingUpdateInput updateDto
    );

    /// <summary>
    /// Get a user_ record for HotelBookings
    /// </summary>
    public Task<User> GetUser(HotelBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a voucher_ record for HotelBookings
    /// </summary>
    public Task<Vouchers> GetVoucher(HotelBookingsWhereUniqueInput uniqueId);
}
