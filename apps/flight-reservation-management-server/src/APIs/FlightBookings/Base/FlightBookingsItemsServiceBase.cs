using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class FlightBookingsServiceBase : IFlightBookingsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public FlightBookingsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one FlightBookings
    /// </summary>
    public async Task<FlightBookings> CreateFlightBookings(FlightBookingCreateInput createDto)
    {
        var flightBookings = new FlightBookingsDbModel
        {
            CancelTicketStatus = createDto.CancelTicketStatus,
            CreatedAt = createDto.CreatedAt,
            IssueTicketStatus = createDto.IssueTicketStatus,
            ItineraryAmount = createDto.ItineraryAmount,
            Markdown = createDto.Markdown,
            Markup = createDto.Markup,
            PaymentStatus = createDto.PaymentStatus,
            Pnr = createDto.Pnr,
            PnrRequestResponse = createDto.PnrRequestResponse,
            Reference = createDto.Reference,
            TicketTimeLimit = createDto.TicketTimeLimit,
            TotalAmount = createDto.TotalAmount,
            UpdatedAt = createDto.UpdatedAt,
            Vat = createDto.Vat,
            VoidTicketStatus = createDto.VoidTicketStatus,
            VoucherAmount = createDto.VoucherAmount
        };

        if (createDto.Id != null)
        {
            flightBookings.Id = createDto.Id;
        }
        if (createDto.User != null)
        {
            flightBookings.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Voucher != null)
        {
            flightBookings.Voucher = await _context
                .VouchersItems.Where(vouchers => createDto.Voucher.Id == vouchers.Id)
                .FirstOrDefaultAsync();
        }

        _context.FlightBookingsItems.Add(flightBookings);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<FlightBookingsDbModel>(flightBookings.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one FlightBookings
    /// </summary>
    public async Task DeleteFlightBookings(FlightBookingsWhereUniqueInput uniqueId)
    {
        var flightBookings = await _context.FlightBookingsItems.FindAsync(uniqueId.Id);
        if (flightBookings == null)
        {
            throw new NotFoundException();
        }

        _context.FlightBookingsItems.Remove(flightBookings);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many FlightBookingsItems
    /// </summary>
    public async Task<List<FlightBookings>> FlightBookingsItems(
        FlightBookingFindManyArgs findManyArgs
    )
    {
        var flightBookingsItems = await _context
            .FlightBookingsItems.Include(x => x.Voucher)
            .Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return flightBookingsItems.ConvertAll(flightBookings => flightBookings.ToDto());
    }

    /// <summary>
    /// Meta data about FlightBookings records
    /// </summary>
    public async Task<MetadataDto> FlightBookingsItemsMeta(FlightBookingFindManyArgs findManyArgs)
    {
        var count = await _context.FlightBookingsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one FlightBookings
    /// </summary>
    public async Task<FlightBookings> FlightBookings(FlightBookingsWhereUniqueInput uniqueId)
    {
        var flightBookingsItems = await this.FlightBookingsItems(
            new FlightBookingFindManyArgs
            {
                Where = new FlightBookingWhereInput { Id = uniqueId.Id }
            }
        );
        var flightBookings = flightBookingsItems.FirstOrDefault();
        if (flightBookings == null)
        {
            throw new NotFoundException();
        }

        return flightBookings;
    }

    /// <summary>
    /// Update one FlightBookings
    /// </summary>
    public async Task UpdateFlightBookings(
        FlightBookingsWhereUniqueInput uniqueId,
        FlightBookingUpdateInput updateDto
    )
    {
        var flightBookings = updateDto.ToModel(uniqueId);

        if (updateDto.User != null)
        {
            flightBookings.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.Voucher != null)
        {
            flightBookings.Voucher = await _context
                .VouchersItems.Where(vouchers => updateDto.Voucher == vouchers.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(flightBookings).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.FlightBookingsItems.Any(e => e.Id == flightBookings.Id))
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
    /// Get a user_ record for FlightBookings
    /// </summary>
    public async Task<User> GetUser(FlightBookingsWhereUniqueInput uniqueId)
    {
        var flightBookings = await _context
            .FlightBookingsItems.Where(flightBookings => flightBookings.Id == uniqueId.Id)
            .Include(flightBookings => flightBookings.User)
            .FirstOrDefaultAsync();
        if (flightBookings == null)
        {
            throw new NotFoundException();
        }
        return flightBookings.User.ToDto();
    }

    /// <summary>
    /// Get a voucher_ record for FlightBookings
    /// </summary>
    public async Task<Vouchers> GetVoucher(FlightBookingsWhereUniqueInput uniqueId)
    {
        var flightBookings = await _context
            .FlightBookingsItems.Where(flightBookings => flightBookings.Id == uniqueId.Id)
            .Include(flightBookings => flightBookings.Voucher)
            .FirstOrDefaultAsync();
        if (flightBookings == null)
        {
            throw new NotFoundException();
        }
        return flightBookings.Voucher.ToDto();
    }
}
