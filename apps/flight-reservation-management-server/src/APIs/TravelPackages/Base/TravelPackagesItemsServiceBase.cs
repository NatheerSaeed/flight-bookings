using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class TravelPackagesServiceBase : ITravelPackagesService
{
    protected readonly FlightReservationManagementDbContext _context;

    public TravelPackagesServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one TravelPackages
    /// </summary>
    public async Task<TravelPackages> CreateTravelPackage(TravelPackageCreateInput inputDto)
    {
        var travelPackages = new TravelPackage
        {
            AdultPrice = inputDto.AdultPrice,
            Attraction = inputDto.Attraction,
            CategoryId = inputDto.CategoryId,
            ChildPrice = inputDto.ChildPrice,
            CreatedAt = inputDto.CreatedAt,
            Flight = inputDto.Flight,
            Hotel = inputDto.Hotel,
            InfantPrice = inputDto.InfantPrice,
            Information = inputDto.Information,
            Name = inputDto.Name,
            PhoneNumber = inputDto.PhoneNumber,
            Status = inputDto.Status,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            travelPackages.Id = inputDto.Id;
        }

        _context.TravelPackagesItems.Add(travelPackages);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TravelPackage>(travelPackages.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one TravelPackages
    /// </summary>
    public async Task DeleteTravelPackage(TravelPackagesWhereUniqueInput uniqueId)
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
        TravelPackageFindManyArgs findManyArgs
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
    public async Task<MetadataDto> TravelPackagesItemsMeta(TravelPackageFindManyArgs findManyArgs)
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
            new TravelPackageFindManyArgs
            {
                Where = new TravelPackageWhereInput { Id = uniqueId.Id }
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
    public async Task UpdateTravelPackage(
        TravelPackagesWhereUniqueInput uniqueId,
        TravelPackageUpdateInput updateDto
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
