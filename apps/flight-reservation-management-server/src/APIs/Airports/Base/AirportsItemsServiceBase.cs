using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class AirportsServiceBase : IAirportsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public AirportsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Airports
    /// </summary>
    public async Task<Airports> CreateAirports(AirportCreateInput inputDto)
    {
        var airports = new Airport
        {
            Code = inputDto.Code,
            CreatedAt = inputDto.CreatedAt,
            Name = inputDto.Name,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            airports.Id = inputDto.Id;
        }

        _context.AirportsItems.Add(airports);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Airport>(airports.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Airports
    /// </summary>
    public async Task DeleteAirports(AirportsWhereUniqueInput uniqueId)
    {
        var airports = await _context.AirportsItems.FindAsync(uniqueId.Id);
        if (airports == null)
        {
            throw new NotFoundException();
        }

        _context.AirportsItems.Remove(airports);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many AirportsItems
    /// </summary>
    public async Task<List<Airports>> AirportsItems(AirportFindManyArgs findManyArgs)
    {
        var airportsItems = await _context
            .AirportsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return airportsItems.ConvertAll(airports => airports.ToDto());
    }

    /// <summary>
    /// Meta data about Airports records
    /// </summary>
    public async Task<MetadataDto> AirportsItemsMeta(AirportFindManyArgs findManyArgs)
    {
        var count = await _context.AirportsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Airports
    /// </summary>
    public async Task<Airports> Airports(AirportsWhereUniqueInput uniqueId)
    {
        var airportsItems = await this.AirportsItems(
            new AirportFindManyArgs { Where = new AirportWhereInput { Id = uniqueId.Id } }
        );
        var airports = airportsItems.FirstOrDefault();
        if (airports == null)
        {
            throw new NotFoundException();
        }

        return airports;
    }

    /// <summary>
    /// Update one Airports
    /// </summary>
    public async Task UpdateAirports(
        AirportsWhereUniqueInput uniqueId,
        AirportUpdateInput updateDto
    )
    {
        var airports = updateDto.ToModel(uniqueId);

        _context.Entry(airports).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.AirportsItems.Any(e => e.Id == airports.Id))
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
