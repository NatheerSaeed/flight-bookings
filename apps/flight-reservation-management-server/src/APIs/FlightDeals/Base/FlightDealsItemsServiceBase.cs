using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class FlightDealsItemsServiceBase : IFlightDealsItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public FlightDealsItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one FlightDeals
    /// </summary>
    public async Task<FlightDeals> CreateFlightDeals(FlightDealsCreateInput createDto)
    {
        var flightDeals = new FlightDealsDbModel
        {
            Airline = createDto.Airline,
            Cabin = createDto.Cabin,
            CreatedAt = createDto.CreatedAt,
            Date = createDto.Date,
            Destination = createDto.Destination,
            Information = createDto.Information,
            Origin = createDto.Origin,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            flightDeals.Id = createDto.Id;
        }
        if (createDto.PackageField != null)
        {
            flightDeals.PackageField = await _context
                .PackagesItems.Where(packages => createDto.PackageField.Id == packages.Id)
                .FirstOrDefaultAsync();
        }

        _context.FlightDealsItems.Add(flightDeals);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<FlightDealsDbModel>(flightDeals.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one FlightDeals
    /// </summary>
    public async Task DeleteFlightDeals(FlightDealsWhereUniqueInput uniqueId)
    {
        var flightDeals = await _context.FlightDealsItems.FindAsync(uniqueId.Id);
        if (flightDeals == null)
        {
            throw new NotFoundException();
        }

        _context.FlightDealsItems.Remove(flightDeals);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many FlightDealsItems
    /// </summary>
    public async Task<List<FlightDeals>> FlightDealsItems(FlightDealsFindManyArgs findManyArgs)
    {
        var flightDealsItems = await _context
            .FlightDealsItems.Include(x => x.PackageField)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return flightDealsItems.ConvertAll(flightDeals => flightDeals.ToDto());
    }

    /// <summary>
    /// Meta data about FlightDeals records
    /// </summary>
    public async Task<MetadataDto> FlightDealsItemsMeta(FlightDealsFindManyArgs findManyArgs)
    {
        var count = await _context.FlightDealsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one FlightDeals
    /// </summary>
    public async Task<FlightDeals> FlightDeals(FlightDealsWhereUniqueInput uniqueId)
    {
        var flightDealsItems = await this.FlightDealsItems(
            new FlightDealsFindManyArgs { Where = new FlightDealsWhereInput { Id = uniqueId.Id } }
        );
        var flightDeals = flightDealsItems.FirstOrDefault();
        if (flightDeals == null)
        {
            throw new NotFoundException();
        }

        return flightDeals;
    }

    /// <summary>
    /// Update one FlightDeals
    /// </summary>
    public async Task UpdateFlightDeals(
        FlightDealsWhereUniqueInput uniqueId,
        FlightDealsUpdateInput updateDto
    )
    {
        var flightDeals = updateDto.ToModel(uniqueId);

        if (updateDto.PackageField != null)
        {
            flightDeals.PackageField = await _context
                .PackagesItems.Where(packages => updateDto.PackageField == packages.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(flightDeals).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.FlightDealsItems.Any(e => e.Id == flightDeals.Id))
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
    /// Get a package_ record for FlightDeals
    /// </summary>
    public async Task<Packages> GetPackageField(FlightDealsWhereUniqueInput uniqueId)
    {
        var flightDeals = await _context
            .FlightDealsItems.Where(flightDeals => flightDeals.Id == uniqueId.Id)
            .Include(flightDeals => flightDeals.PackageField)
            .FirstOrDefaultAsync();
        if (flightDeals == null)
        {
            throw new NotFoundException();
        }
        return flightDeals.PackageField.ToDto();
    }
}
