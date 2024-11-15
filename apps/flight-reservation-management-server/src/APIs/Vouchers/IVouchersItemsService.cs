using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IVouchersService
{
    /// <summary>
    /// Create one Vouchers
    /// </summary>
    public Task<Vouchers> CreateVoucher(VoucherCreateInput vouchers);

    /// <summary>
    /// Delete one Vouchers
    /// </summary>
    public Task DeleteVoucher(VouchersWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many VouchersItems
    /// </summary>
    public Task<List<Vouchers>> VouchersSearchAsync(VoucherFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Vouchers records
    /// </summary>
    public Task<MetadataDto> VouchersItemsMeta(VoucherFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Vouchers
    /// </summary>
    public Task<Vouchers> Vouchers(VouchersWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Vouchers
    /// </summary>
    public Task UpdateVoucher(VouchersWhereUniqueInput uniqueId, VoucherUpdateInput updateDto);

    /// <summary>
    /// Connect multiple FlightBookingsItems records to Vouchers
    /// </summary>
    public Task ConnectFlightBookingsSearchAsync(
        VouchersWhereUniqueInput uniqueId,
        FlightBookingsWhereUniqueInput[] flightBookingsId
    );

    /// <summary>
    /// Disconnect multiple FlightBookingsItems records from Vouchers
    /// </summary>
    public Task DisconnectFlightBookingsSearchAsync(
        VouchersWhereUniqueInput uniqueId,
        FlightBookingsWhereUniqueInput[] flightBookingsId
    );

    /// <summary>
    /// Find multiple FlightBookingsItems records for Vouchers
    /// </summary>
    public Task<List<FlightBookings>> FindFlightBookingsSearchAsync(
        VouchersWhereUniqueInput uniqueId,
        FlightBookingFindManyArgs FlightBookingFindManyArgs
    );

    /// <summary>
    /// Update multiple FlightBookingsItems records for Vouchers
    /// </summary>
    public Task UpdateFlightBookingsItem(
        VouchersWhereUniqueInput uniqueId,
        FlightBookingsWhereUniqueInput[] flightBookingsId
    );

    /// <summary>
    /// Connect multiple HotelBookingsItems records to Vouchers
    /// </summary>
    public Task ConnectHotelBookingsSearchAsync(
        VouchersWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] hotelBookingsId
    );

    /// <summary>
    /// Disconnect multiple HotelBookingsItems records from Vouchers
    /// </summary>
    public Task DisconnectHotelBookingsSearchAsync(
        VouchersWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] hotelBookingsId
    );

    /// <summary>
    /// Find multiple HotelBookingsItems records for Vouchers
    /// </summary>
    public Task<List<HotelBookings>> FindHotelBookingsSearchAsync(
        VouchersWhereUniqueInput uniqueId,
        HotelBookingFindManyArgs HotelBookingFindManyArgs
    );

    /// <summary>
    /// Update multiple HotelBookingsItems records for Vouchers
    /// </summary>
    public Task UpdateHotelBookingsItem(
        VouchersWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] hotelBookingsId
    );
}
