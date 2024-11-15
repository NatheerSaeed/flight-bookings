using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IFlightBookingsService
{
    /// <summary>
    /// Create one FlightBookings
    /// </summary>
    public Task<FlightBookings> CreateFlightBooking(FlightBookingCreateInput flightbookings);

    /// <summary>
    /// Delete one FlightBookings
    /// </summary>
    public Task DeleteFlightBooking(FlightBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many FlightBookingsItems
    /// </summary>
    public Task<List<FlightBookings>> FlightBookingsItems(FlightBookingFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about FlightBookings records
    /// </summary>
    public Task<MetadataDto> FlightBookingsItemsMeta(FlightBookingFindManyArgs findManyArgs);

    /// <summary>
    /// Get one FlightBookings
    /// </summary>
    public Task<FlightBookings> FlightBookings(FlightBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one FlightBookings
    /// </summary>
    public Task UpdateFlightBooking(
        FlightBookingsWhereUniqueInput uniqueId,
        FlightBookingUpdateInput updateDto
    );

    /// <summary>
    /// Get a user_ record for FlightBookings
    /// </summary>
    public Task<User> GetUser(FlightBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a voucher_ record for FlightBookings
    /// </summary>
    public Task<Vouchers> GetVoucher(FlightBookingsWhereUniqueInput uniqueId);
}
