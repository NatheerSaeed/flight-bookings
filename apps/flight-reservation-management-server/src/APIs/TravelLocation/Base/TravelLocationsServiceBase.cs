using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class TravelLocationsServiceBase : ITravelLocationsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public TravelLocationsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one TravelLocation
    /// </summary>
    public async Task<TravelLocation> CreateTravelLocation(TravelLocationCreateInput createDto)
    {
        var travelLocation = new TravelLocationDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            travelLocation.Id = createDto.Id;
        }

        _context.TravelLocations.Add(travelLocation);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TravelLocationDbModel>(travelLocation.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one TravelLocation
    /// </summary>
    public async Task DeleteTravelLocation(TravelLocationWhereUniqueInput uniqueId)
    {
        var travelLocation = await _context.TravelLocations.FindAsync(uniqueId.Id);
        if (travelLocation == null)
        {
            throw new NotFoundException();
        }

        _context.TravelLocations.Remove(travelLocation);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many TravelLocations
    /// </summary>
    public async Task<List<TravelLocation>> TravelLocations(TravelLocationFindManyArgs findManyArgs)
    {
        var travelLocations = await _context
            .TravelLocations.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return travelLocations.ConvertAll(travelLocation => travelLocation.ToDto());
    }

    /// <summary>
    /// Meta data about TravelLocation records
    /// </summary>
    public async Task<MetadataDto> TravelLocationsMeta(TravelLocationFindManyArgs findManyArgs)
    {
        var count = await _context.TravelLocations.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one TravelLocation
    /// </summary>
    public async Task<TravelLocation> TravelLocation(TravelLocationWhereUniqueInput uniqueId)
    {
        var travelLocations = await this.TravelLocations(
            new TravelLocationFindManyArgs
            {
                Where = new TravelLocationWhereInput { Id = uniqueId.Id }
            }
        );
        var travelLocation = travelLocations.FirstOrDefault();
        if (travelLocation == null)
        {
            throw new NotFoundException();
        }

        return travelLocation;
    }

    /// <summary>
    /// Update one TravelLocation
    /// </summary>
    public async Task UpdateTravelLocation(
        TravelLocationWhereUniqueInput uniqueId,
        TravelLocationUpdateInput updateDto
    )
    {
        var travelLocation = updateDto.ToModel(uniqueId);

        _context.Entry(travelLocation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.TravelLocations.Any(e => e.Id == travelLocation.Id))
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
