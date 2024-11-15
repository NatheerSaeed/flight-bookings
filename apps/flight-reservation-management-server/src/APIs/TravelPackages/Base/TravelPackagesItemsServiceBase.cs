using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class TravelPackagesItemsServiceBase : ITravelPackagesItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public TravelPackagesItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one TravelPackages
    /// </summary>
    public async Task<TravelPackages> CreateTravelPackages(TravelPackagesCreateInput createDto)
    {
        var travelPackages = new TravelPackagesDbModel
        {
            AdultPrice = createDto.AdultPrice,
            Attraction = createDto.Attraction,
            CategoryId = createDto.CategoryId,
            ChildPrice = createDto.ChildPrice,
            CreatedAt = createDto.CreatedAt,
            Flight = createDto.Flight,
            Hotel = createDto.Hotel,
            InfantPrice = createDto.InfantPrice,
            Information = createDto.Information,
            Name = createDto.Name,
            PhoneNumber = createDto.PhoneNumber,
            Status = createDto.Status,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            travelPackages.Id = createDto.Id;
        }

        _context.TravelPackagesItems.Add(travelPackages);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TravelPackagesDbModel>(travelPackages.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one TravelPackages
    /// </summary>
    public async Task DeleteTravelPackages(TravelPackagesWhereUniqueInput uniqueId)
    {
        var travelPackages = await _context.TravelPackagesItems.FindAsync(uniqueId.Id);
        if (travelPackages == null)
        {
            throw new NotFoundException();
        }

        _context.TravelPackagesItems.Remove(travelPackages);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many TravelPackagesItems
    /// </summary>
    public async Task<List<TravelPackages>> TravelPackagesItems(
        TravelPackagesFindManyArgs findManyArgs
    )
    {
        var travelPackagesItems = await _context
            .TravelPackagesItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return travelPackagesItems.ConvertAll(travelPackages => travelPackages.ToDto());
    }

    /// <summary>
    /// Meta data about TravelPackages records
    /// </summary>
    public async Task<MetadataDto> TravelPackagesItemsMeta(TravelPackagesFindManyArgs findManyArgs)
    {
        var count = await _context.TravelPackagesItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one TravelPackages
    /// </summary>
    public async Task<TravelPackages> TravelPackages(TravelPackagesWhereUniqueInput uniqueId)
    {
        var travelPackagesItems = await this.TravelPackagesItems(
            new TravelPackagesFindManyArgs
            {
                Where = new TravelPackagesWhereInput { Id = uniqueId.Id }
            }
        );
        var travelPackages = travelPackagesItems.FirstOrDefault();
        if (travelPackages == null)
        {
            throw new NotFoundException();
        }

        return travelPackages;
    }

    /// <summary>
    /// Update one TravelPackages
    /// </summary>
    public async Task UpdateTravelPackages(
        TravelPackagesWhereUniqueInput uniqueId,
        TravelPackagesUpdateInput updateDto
    )
    {
        var travelPackages = updateDto.ToModel(uniqueId);

        _context.Entry(travelPackages).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.TravelPackagesItems.Any(e => e.Id == travelPackages.Id))
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
