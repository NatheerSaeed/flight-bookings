using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IHotelBookingsItemsService
{
    /// <summary>
    /// Create one HotelBookings
    /// </summary>
    public Task<HotelBookings> CreateHotelBookings(HotelBookingsCreateInput hotelbookings);

    /// <summary>
    /// Delete one HotelBookings
    /// </summary>
    public Task DeleteHotelBookings(HotelBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many HotelBookingsItems
    /// </summary>
    public Task<List<HotelBookings>> HotelBookingsItems(HotelBookingsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about HotelBookings records
    /// </summary>
    public Task<MetadataDto> HotelBookingsItemsMeta(HotelBookingsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one HotelBookings
    /// </summary>
    public Task<HotelBookings> HotelBookings(HotelBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one HotelBookings
    /// </summary>
    public Task UpdateHotelBookings(
        HotelBookingsWhereUniqueInput uniqueId,
        HotelBookingsUpdateInput updateDto
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
