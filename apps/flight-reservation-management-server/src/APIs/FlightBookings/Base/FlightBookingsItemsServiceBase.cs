using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class FlightBookingsItemsServiceBase : IFlightBookingsItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public FlightBookingsItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one FlightBookings
    /// </summary>
    public async Task<FlightBookings> CreateFlightBookings(FlightBookingsCreateInput createDto)
    {
        var flightBookings = new FlightBookingsDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            flightBookings.Id = createDto.Id;
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
        FlightBookingsFindManyArgs findManyArgs
    )
    {
        var flightBookingsItems = await _context
            .FlightBookingsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return flightBookingsItems.ConvertAll(flightBookings => flightBookings.ToDto());
    }

    /// <summary>
    /// Meta data about FlightBookings records
    /// </summary>
    public async Task<MetadataDto> FlightBookingsItemsMeta(FlightBookingsFindManyArgs findManyArgs)
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
            new FlightBookingsFindManyArgs
            {
                Where = new FlightBookingsWhereInput { Id = uniqueId.Id }
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
        FlightBookingsUpdateInput updateDto
    )
    {
        var flightBookings = updateDto.ToModel(uniqueId);

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
}
