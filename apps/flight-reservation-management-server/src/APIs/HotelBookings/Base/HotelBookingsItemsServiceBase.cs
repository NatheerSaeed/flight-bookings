using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class HotelBookingsServiceBase : IHotelBookingsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public HotelBookingsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one HotelBookings
    /// </summary>
    public async Task<HotelBookings> CreateHotelBooking(HotelBookingCreateInput inputDto)
    {
        var hotelBookings = new HotelBooking
        {
            AdultGuest = inputDto.AdultGuest,
            BaseAmount = inputDto.BaseAmount,
            CancellationStatus = inputDto.CancellationStatus,
            CheckInDate = inputDto.CheckInDate,
            CheckOutDate = inputDto.CheckOutDate,
            ChildGuest = inputDto.ChildGuest,
            CreatedAt = inputDto.CreatedAt,
            ExpiryDate = inputDto.ExpiryDate,
            Guarantee = inputDto.Guarantee,
            HotelChainCode = inputDto.HotelChainCode,
            HotelCityCode = inputDto.HotelCityCode,
            HotelCode = inputDto.HotelCode,
            HotelContextCode = inputDto.HotelContextCode,
            HotelName = inputDto.HotelName,
            Markdown = inputDto.Markdown,
            Markup = inputDto.Markup,
            PaymentStatus = inputDto.PaymentStatus,
            Pnr = inputDto.Pnr,
            PnrRequestResponse = inputDto.PnrRequestResponse,
            RatePlanCode = inputDto.RatePlanCode,
            Reference = inputDto.Reference,
            ReservationStatus = inputDto.ReservationStatus,
            RoomBookingCode = inputDto.RoomBookingCode,
            TotalAmount = inputDto.TotalAmount,
            UpdatedAt = inputDto.UpdatedAt,
            Vat = inputDto.Vat,
            VoucherAmount = inputDto.VoucherAmount
        };

        if (inputDto.Id != null)
        {
            hotelBookings.Id = inputDto.Id;
        }
        if (inputDto.User != null)
        {
            hotelBookings.User = await _context
                .Users.Where(user => inputDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        if (inputDto.Voucher != null)
        {
            hotelBookings.Voucher = await _context
                .VouchersItems.Where(vouchers => inputDto.Voucher.Id == vouchers.Id)
                .FirstOrDefaultAsync();
        }

        _context.HotelBookingsItems.Add(hotelBookings);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<HotelBooking>(hotelBookings.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one HotelBookings
    /// </summary>
    public async Task DeleteHotelBooking(HotelBookingsWhereUniqueInput uniqueId)
    {
        var hotelBookings = await _context.HotelBookingsItems.FindAsync(uniqueId.Id);
        if (hotelBookings == null)
        {
            throw new NotFoundException();
        }

        _context.HotelBookingsItems.Remove(hotelBookings);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many HotelBookingsItems
    /// </summary>
    public async Task<List<HotelBookings>> HotelBookingsSearchAsync(
        HotelBookingFindManyArgs findManyArgs
    )
    {
        var hotelBookingsItems = await _context
            .HotelBookingsItems.Include(x => x.Voucher)
            .Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return hotelBookingsItems.ConvertAll(hotelBookings => hotelBookings.ToDto());
    }

    /// <summary>
    /// Meta data about HotelBookings records
    /// </summary>
    public async Task<MetadataDto> HotelBookingsItemsMeta(HotelBookingFindManyArgs findManyArgs)
    {
        var count = await _context.HotelBookingsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one HotelBookings
    /// </summary>
    public async Task<HotelBookings> HotelBookings(HotelBookingsWhereUniqueInput uniqueId)
    {
        var hotelBookingsItems = await this.HotelBookingsSearchAsync(
            new HotelBookingFindManyArgs { Where = new HotelBookingWhereInput { Id = uniqueId.Id } }
        );
        var hotelBookings = hotelBookingsItems.FirstOrDefault();
        if (hotelBookings == null)
        {
            throw new NotFoundException();
        }

        return hotelBookings;
    }

    /// <summary>
    /// Update one HotelBookings
    /// </summary>
    public async Task UpdateHotelBooking(
        HotelBookingsWhereUniqueInput uniqueId,
        HotelBookingUpdateInput updateDto
    )
    {
        var hotelBookings = updateDto.ToModel(uniqueId);

        if (updateDto.User != null)
        {
            hotelBookings.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.Voucher != null)
        {
            hotelBookings.Voucher = await _context
                .VouchersItems.Where(vouchers => updateDto.Voucher == vouchers.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(hotelBookings).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.HotelBookingsItems.Any(e => e.Id == hotelBookings.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Get a user_ record for HotelBookings
    /// </summary>
    public async Task<User> GetUser(HotelBookingsWhereUniqueInput uniqueId)
    {
        var hotelBookings = await _context
            .HotelBookingsItems.Where(hotelBookings => hotelBookings.Id == uniqueId.Id)
            .Include(hotelBookings => hotelBookings.User)
            .FirstOrDefaultAsync();
        if (hotelBookings == null)
        {
            throw new NotFoundException();
        }
        return hotelBookings.User.ToDto();
    }

    /// <summary>
    /// Get a voucher_ record for HotelBookings
    /// </summary>
    public async Task<Vouchers> GetVoucher(HotelBookingsWhereUniqueInput uniqueId)
    {
        var hotelBookings = await _context
            .HotelBookingsItems.Where(hotelBookings => hotelBookings.Id == uniqueId.Id)
            .Include(hotelBookings => hotelBookings.Voucher)
            .FirstOrDefaultAsync();
        if (hotelBookings == null)
        {
            throw new NotFoundException();
        }
        return hotelBookings.Voucher.ToDto();
    }
}
