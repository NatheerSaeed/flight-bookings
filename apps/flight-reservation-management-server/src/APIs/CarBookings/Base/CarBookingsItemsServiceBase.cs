using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class CarBookingsItemsServiceBase : ICarBookingsItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public CarBookingsItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one CarBookings
    /// </summary>
    public async Task<CarBookings> CreateCarBookings(CarBookingsCreateInput createDto)
    {
        var carBookings = new CarBookingsDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            carBookings.Id = createDto.Id;
        }

        _context.CarBookingsItems.Add(carBookings);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CarBookingsDbModel>(carBookings.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one CarBookings
    /// </summary>
    public async Task DeleteCarBookings(CarBookingsWhereUniqueInput uniqueId)
    {
        var carBookings = await _context.CarBookingsItems.FindAsync(uniqueId.Id);
        if (carBookings == null)
        {
            throw new NotFoundException();
        }

        _context.CarBookingsItems.Remove(carBookings);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many CarBookingsItems
    /// </summary>
    public async Task<List<CarBookings>> CarBookingsItems(CarBookingsFindManyArgs findManyArgs)
    {
        var carBookingsItems = await _context
            .CarBookingsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return carBookingsItems.ConvertAll(carBookings => carBookings.ToDto());
    }

    /// <summary>
    /// Meta data about CarBookings records
    /// </summary>
    public async Task<MetadataDto> CarBookingsItemsMeta(CarBookingsFindManyArgs findManyArgs)
    {
        var count = await _context.CarBookingsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one CarBookings
    /// </summary>
    public async Task<CarBookings> CarBookings(CarBookingsWhereUniqueInput uniqueId)
    {
        var carBookingsItems = await this.CarBookingsItems(
            new CarBookingsFindManyArgs { Where = new CarBookingsWhereInput { Id = uniqueId.Id } }
        );
        var carBookings = carBookingsItems.FirstOrDefault();
        if (carBookings == null)
        {
            throw new NotFoundException();
        }

        return carBookings;
    }

    /// <summary>
    /// Update one CarBookings
    /// </summary>
    public async Task UpdateCarBookings(
        CarBookingsWhereUniqueInput uniqueId,
        CarBookingsUpdateInput updateDto
    )
    {
        var carBookings = updateDto.ToModel(uniqueId);

        _context.Entry(carBookings).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.CarBookingsItems.Any(e => e.Id == carBookings.Id))
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
