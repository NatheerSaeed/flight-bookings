using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IFlightBookingsItemsService
{
    /// <summary>
    /// Create one FlightBookings
    /// </summary>
    public Task<FlightBookings> CreateFlightBookings(FlightBookingsCreateInput flightbookings);

    /// <summary>
    /// Delete one FlightBookings
    /// </summary>
    public Task DeleteFlightBookings(FlightBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many FlightBookingsItems
    /// </summary>
    public Task<List<FlightBookings>> FlightBookingsItems(FlightBookingsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about FlightBookings records
    /// </summary>
    public Task<MetadataDto> FlightBookingsItemsMeta(FlightBookingsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one FlightBookings
    /// </summary>
    public Task<FlightBookings> FlightBookings(FlightBookingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one FlightBookings
    /// </summary>
    public Task UpdateFlightBookings(
        FlightBookingsWhereUniqueInput uniqueId,
        FlightBookingsUpdateInput updateDto
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
