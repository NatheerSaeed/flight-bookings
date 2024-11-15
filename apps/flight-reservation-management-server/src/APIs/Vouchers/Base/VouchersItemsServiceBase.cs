using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class VouchersItemsServiceBase : IVouchersItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public VouchersItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Vouchers
    /// </summary>
    public async Task<Vouchers> CreateVouchers(VouchersCreateInput createDto)
    {
        var vouchers = new VouchersDbModel
        {
            Amount = createDto.Amount,
            Code = createDto.Code,
            CreatedAt = createDto.CreatedAt,
            Status = createDto.Status,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            vouchers.Id = createDto.Id;
        }
        if (createDto.FlightBookingsItems != null)
        {
            vouchers.FlightBookingsItems = await _context
                .FlightBookingsItems.Where(flightBookings =>
                    createDto.FlightBookingsItems.Select(t => t.Id).Contains(flightBookings.Id)
                )
                .ToListAsync();
        }

        if (createDto.HotelBookingsItems != null)
        {
            vouchers.HotelBookingsItems = await _context
                .HotelBookingsItems.Where(hotelBookings =>
                    createDto.HotelBookingsItems.Select(t => t.Id).Contains(hotelBookings.Id)
                )
                .ToListAsync();
        }

        _context.VouchersItems.Add(vouchers);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<VouchersDbModel>(vouchers.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Vouchers
    /// </summary>
    public async Task DeleteVouchers(VouchersWhereUniqueInput uniqueId)
    {
        var vouchers = await _context.VouchersItems.FindAsync(uniqueId.Id);
        if (vouchers == null)
        {
            throw new NotFoundException();
        }

        _context.VouchersItems.Remove(vouchers);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many VouchersItems
    /// </summary>
    public async Task<List<Vouchers>> VouchersItems(VouchersFindManyArgs findManyArgs)
    {
        var vouchersItems = await _context
            .VouchersItems.Include(x => x.HotelBookingsItems)
            .Include(x => x.FlightBookingsItems)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return vouchersItems.ConvertAll(vouchers => vouchers.ToDto());
    }

    /// <summary>
    /// Meta data about Vouchers records
    /// </summary>
    public async Task<MetadataDto> VouchersItemsMeta(VouchersFindManyArgs findManyArgs)
    {
        var count = await _context.VouchersItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Vouchers
    /// </summary>
    public async Task<Vouchers> Vouchers(VouchersWhereUniqueInput uniqueId)
    {
        var vouchersItems = await this.VouchersItems(
            new VouchersFindManyArgs { Where = new VouchersWhereInput { Id = uniqueId.Id } }
        );
        var vouchers = vouchersItems.FirstOrDefault();
        if (vouchers == null)
        {
            throw new NotFoundException();
        }

        return vouchers;
    }

    /// <summary>
    /// Update one Vouchers
    /// </summary>
    public async Task UpdateVouchers(
        VouchersWhereUniqueInput uniqueId,
        VouchersUpdateInput updateDto
    )
    {
        var vouchers = updateDto.ToModel(uniqueId);

        if (updateDto.FlightBookingsItems != null)
        {
            vouchers.FlightBookingsItems = await _context
                .FlightBookingsItems.Where(flightBookings =>
                    updateDto.FlightBookingsItems.Select(t => t).Contains(flightBookings.Id)
                )
                .ToListAsync();
        }

        if (updateDto.HotelBookingsItems != null)
        {
            vouchers.HotelBookingsItems = await _context
                .HotelBookingsItems.Where(hotelBookings =>
                    updateDto.HotelBookingsItems.Select(t => t).Contains(hotelBookings.Id)
                )
                .ToListAsync();
        }

        _context.Entry(vouchers).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.VouchersItems.Any(e => e.Id == vouchers.Id))
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
    /// Connect multiple FlightBookingsItems records to Vouchers
    /// </summary>
    public async Task ConnectFlightBookingsItems(
        VouchersWhereUniqueInput uniqueId,
        FlightBookingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .VouchersItems.Include(x => x.FlightBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .FlightBookingsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.FlightBookingsItems);

        foreach (var child in childrenToConnect)
        {
            parent.FlightBookingsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple FlightBookingsItems records from Vouchers
    /// </summary>
    public async Task DisconnectFlightBookingsItems(
        VouchersWhereUniqueInput uniqueId,
        FlightBookingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .VouchersItems.Include(x => x.FlightBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .FlightBookingsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.FlightBookingsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple FlightBookingsItems records for Vouchers
    /// </summary>
    public async Task<List<FlightBookings>> FindFlightBookingsItems(
        VouchersWhereUniqueInput uniqueId,
        FlightBookingsFindManyArgs vouchersFindManyArgs
    )
    {
        var flightBookingsItems = await _context
            .FlightBookingsItems.Where(m => m.VoucherId == uniqueId.Id)
            .ApplyWhere(vouchersFindManyArgs.Where)
            .ApplySkip(vouchersFindManyArgs.Skip)
            .ApplyTake(vouchersFindManyArgs.Take)
            .ApplyOrderBy(vouchersFindManyArgs.SortBy)
            .ToListAsync();

        return flightBookingsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple FlightBookingsItems records for Vouchers
    /// </summary>
    public async Task UpdateFlightBookingsItems(
        VouchersWhereUniqueInput uniqueId,
        FlightBookingsWhereUniqueInput[] childrenIds
    )
    {
        var vouchers = await _context
            .VouchersItems.Include(t => t.FlightBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (vouchers == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .FlightBookingsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        vouchers.FlightBookingsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple HotelBookingsItems records to Vouchers
    /// </summary>
    public async Task ConnectHotelBookingsItems(
        VouchersWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .VouchersItems.Include(x => x.HotelBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .HotelBookingsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.HotelBookingsItems);

        foreach (var child in childrenToConnect)
        {
            parent.HotelBookingsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple HotelBookingsItems records from Vouchers
    /// </summary>
    public async Task DisconnectHotelBookingsItems(
        VouchersWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .VouchersItems.Include(x => x.HotelBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .HotelBookingsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.HotelBookingsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple HotelBookingsItems records for Vouchers
    /// </summary>
    public async Task<List<HotelBookings>> FindHotelBookingsItems(
        VouchersWhereUniqueInput uniqueId,
        HotelBookingsFindManyArgs vouchersFindManyArgs
    )
    {
        var hotelBookingsItems = await _context
            .HotelBookingsItems.Where(m => m.VoucherId == uniqueId.Id)
            .ApplyWhere(vouchersFindManyArgs.Where)
            .ApplySkip(vouchersFindManyArgs.Skip)
            .ApplyTake(vouchersFindManyArgs.Take)
            .ApplyOrderBy(vouchersFindManyArgs.SortBy)
            .ToListAsync();

        return hotelBookingsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple HotelBookingsItems records for Vouchers
    /// </summary>
    public async Task UpdateHotelBookingsItems(
        VouchersWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] childrenIds
    )
    {
        var vouchers = await _context
            .VouchersItems.Include(t => t.HotelBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (vouchers == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .HotelBookingsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        vouchers.HotelBookingsItems = children;
        await _context.SaveChangesAsync();
    }
}
