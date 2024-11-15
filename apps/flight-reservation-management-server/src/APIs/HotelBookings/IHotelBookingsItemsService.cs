using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IHotelBookingsService
{
    /// <summary>
    /// Create one HotelBookings
    /// </summary>
    public Task<HotelBookings> CreateHotelBookings(HotelBookingCreateInput hotelbookings);

    /// <summary>
    /// Delete one HotelBookings
    /// </summary>
    public Task DeleteHotelBookings(HotelBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many HotelBookingsItems
    /// </summary>
    public Task<List<HotelBookings>> HotelBookingsItems(HotelBookingFindManyArgs findManyArgs);

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
    public Task UpdateHotelBookings(
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
