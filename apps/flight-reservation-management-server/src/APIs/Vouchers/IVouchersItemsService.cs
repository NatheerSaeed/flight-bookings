using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IVouchersItemsService
{
    /// <summary>
    /// Create one Vouchers
    /// </summary>
    public Task<Vouchers> CreateVouchers(VouchersCreateInput vouchers);

    /// <summary>
    /// Delete one Vouchers
    /// </summary>
    public Task DeleteVouchers(VouchersWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many VouchersItems
    /// </summary>
    public Task<List<Vouchers>> VouchersItems(VouchersFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Vouchers records
    /// </summary>
    public Task<MetadataDto> VouchersItemsMeta(VouchersFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Vouchers
    /// </summary>
    public Task<Vouchers> Vouchers(VouchersWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Vouchers
    /// </summary>
    public Task UpdateVouchers(VouchersWhereUniqueInput uniqueId, VouchersUpdateInput updateDto);

    /// <summary>
    /// Connect multiple HotelBookingsItems records to Vouchers
    /// </summary>
    public Task ConnectHotelBookingsItems(
        VouchersWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] hotelBookingsId
    );

    /// <summary>
    /// Disconnect multiple HotelBookingsItems records from Vouchers
    /// </summary>
    public Task DisconnectHotelBookingsItems(
        VouchersWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] hotelBookingsId
    );

    /// <summary>
    /// Find multiple HotelBookingsItems records for Vouchers
    /// </summary>
    public Task<List<HotelBookings>> FindHotelBookingsItems(
        VouchersWhereUniqueInput uniqueId,
        HotelBookingsFindManyArgs HotelBookingsFindManyArgs
    );

    /// <summary>
    /// Update multiple HotelBookingsItems records for Vouchers
    /// </summary>
    public Task UpdateHotelBookingsItems(
        VouchersWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] hotelBookingsId
    );
}
