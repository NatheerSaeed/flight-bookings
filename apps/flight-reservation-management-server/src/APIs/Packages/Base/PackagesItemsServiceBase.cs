using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class PackagesItemsServiceBase : IPackagesItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public PackagesItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Packages
    /// </summary>
    public async Task<Packages> CreatePackages(PackagesCreateInput createDto)
    {
        var packages = new PackagesDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            packages.Id = createDto.Id;
        }
        if (createDto.AttractionsItems != null)
        {
            packages.AttractionsItems = await _context
                .AttractionsItems.Where(attractions =>
                    createDto.AttractionsItems.Select(t => t.Id).Contains(attractions.Id)
                )
                .ToListAsync();
        }

        if (createDto.FlightDealsItems != null)
        {
            packages.FlightDealsItems = await _context
                .FlightDealsItems.Where(flightDeals =>
                    createDto.FlightDealsItems.Select(t => t.Id).Contains(flightDeals.Id)
                )
                .ToListAsync();
        }

        if (createDto.HotelDealsItems != null)
        {
            packages.HotelDealsItems = await _context
                .HotelDealsItems.Where(hotelDeals =>
                    createDto.HotelDealsItems.Select(t => t.Id).Contains(hotelDeals.Id)
                )
                .ToListAsync();
        }

        if (createDto.PackageFlightsItems != null)
        {
            packages.PackageFlightsItems = await _context
                .PackageFlightsItems.Where(packageFlights =>
                    createDto.PackageFlightsItems.Select(t => t.Id).Contains(packageFlights.Id)
                )
                .ToListAsync();
        }

        if (createDto.PackageHotelsItems != null)
        {
            packages.PackageHotelsItems = await _context
                .PackageHotelsItems.Where(packageHotels =>
                    createDto.PackageHotelsItems.Select(t => t.Id).Contains(packageHotels.Id)
                )
                .ToListAsync();
        }

        if (createDto.SightSeeingsItems != null)
        {
            packages.SightSeeingsItems = await _context
                .SightSeeingsItems.Where(sightSeeings =>
                    createDto.SightSeeingsItems.Select(t => t.Id).Contains(sightSeeings.Id)
                )
                .ToListAsync();
        }

        _context.PackagesItems.Add(packages);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PackagesDbModel>(packages.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Packages
    /// </summary>
    public async Task DeletePackages(PackagesWhereUniqueInput uniqueId)
    {
        var packages = await _context.PackagesItems.FindAsync(uniqueId.Id);
        if (packages == null)
        {
            throw new NotFoundException();
        }

        _context.PackagesItems.Remove(packages);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many PackagesItems
    /// </summary>
    public async Task<List<Packages>> PackagesItems(PackagesFindManyArgs findManyArgs)
    {
        var packagesItems = await _context
            .PackagesItems.Include(x => x.SightSeeingsItems)
            .Include(x => x.PackageHotelsItems)
            .Include(x => x.AttractionsItems)
            .Include(x => x.FlightDealsItems)
            .Include(x => x.HotelDealsItems)
            .Include(x => x.PackageFlightsItems)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return packagesItems.ConvertAll(packages => packages.ToDto());
    }

    /// <summary>
    /// Meta data about Packages records
    /// </summary>
    public async Task<MetadataDto> PackagesItemsMeta(PackagesFindManyArgs findManyArgs)
    {
        var count = await _context.PackagesItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Packages
    /// </summary>
    public async Task<Packages> Packages(PackagesWhereUniqueInput uniqueId)
    {
        var packagesItems = await this.PackagesItems(
            new PackagesFindManyArgs { Where = new PackagesWhereInput { Id = uniqueId.Id } }
        );
        var packages = packagesItems.FirstOrDefault();
        if (packages == null)
        {
            throw new NotFoundException();
        }

        return packages;
    }

    /// <summary>
    /// Update one Packages
    /// </summary>
    public async Task UpdatePackages(
        PackagesWhereUniqueInput uniqueId,
        PackagesUpdateInput updateDto
    )
    {
        var packages = updateDto.ToModel(uniqueId);

        if (updateDto.AttractionsItems != null)
        {
            packages.AttractionsItems = await _context
                .AttractionsItems.Where(attractions =>
                    updateDto.AttractionsItems.Select(t => t).Contains(attractions.Id)
                )
                .ToListAsync();
        }

        if (updateDto.FlightDealsItems != null)
        {
            packages.FlightDealsItems = await _context
                .FlightDealsItems.Where(flightDeals =>
                    updateDto.FlightDealsItems.Select(t => t).Contains(flightDeals.Id)
                )
                .ToListAsync();
        }

        if (updateDto.HotelDealsItems != null)
        {
            packages.HotelDealsItems = await _context
                .HotelDealsItems.Where(hotelDeals =>
                    updateDto.HotelDealsItems.Select(t => t).Contains(hotelDeals.Id)
                )
                .ToListAsync();
        }

        if (updateDto.PackageFlightsItems != null)
        {
            packages.PackageFlightsItems = await _context
                .PackageFlightsItems.Where(packageFlights =>
                    updateDto.PackageFlightsItems.Select(t => t).Contains(packageFlights.Id)
                )
                .ToListAsync();
        }

        if (updateDto.PackageHotelsItems != null)
        {
            packages.PackageHotelsItems = await _context
                .PackageHotelsItems.Where(packageHotels =>
                    updateDto.PackageHotelsItems.Select(t => t).Contains(packageHotels.Id)
                )
                .ToListAsync();
        }

        if (updateDto.SightSeeingsItems != null)
        {
            packages.SightSeeingsItems = await _context
                .SightSeeingsItems.Where(sightSeeings =>
                    updateDto.SightSeeingsItems.Select(t => t).Contains(sightSeeings.Id)
                )
                .ToListAsync();
        }

        _context.Entry(packages).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PackagesItems.Any(e => e.Id == packages.Id))
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
    /// Connect multiple AttractionsItems records to Packages
    /// </summary>
    public async Task ConnectAttractionsItems(
        PackagesWhereUniqueInput uniqueId,
        AttractionsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.AttractionsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .AttractionsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.AttractionsItems);

        foreach (var child in childrenToConnect)
        {
            parent.AttractionsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple AttractionsItems records from Packages
    /// </summary>
    public async Task DisconnectAttractionsItems(
        PackagesWhereUniqueInput uniqueId,
        AttractionsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.AttractionsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .AttractionsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.AttractionsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple AttractionsItems records for Packages
    /// </summary>
    public async Task<List<Attractions>> FindAttractionsItems(
        PackagesWhereUniqueInput uniqueId,
        AttractionsFindManyArgs packagesFindManyArgs
    )
    {
        var attractionsItems = await _context
            .AttractionsItems.Where(m => m.PackageFieldId == uniqueId.Id)
            .ApplyWhere(packagesFindManyArgs.Where)
            .ApplySkip(packagesFindManyArgs.Skip)
            .ApplyTake(packagesFindManyArgs.Take)
            .ApplyOrderBy(packagesFindManyArgs.SortBy)
            .ToListAsync();

        return attractionsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple AttractionsItems records for Packages
    /// </summary>
    public async Task UpdateAttractionsItems(
        PackagesWhereUniqueInput uniqueId,
        AttractionsWhereUniqueInput[] childrenIds
    )
    {
        var packages = await _context
            .PackagesItems.Include(t => t.AttractionsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (packages == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .AttractionsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        packages.AttractionsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple FlightDealsItems records to Packages
    /// </summary>
    public async Task ConnectFlightDealsItems(
        PackagesWhereUniqueInput uniqueId,
        FlightDealsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.FlightDealsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .FlightDealsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.FlightDealsItems);

        foreach (var child in childrenToConnect)
        {
            parent.FlightDealsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple FlightDealsItems records from Packages
    /// </summary>
    public async Task DisconnectFlightDealsItems(
        PackagesWhereUniqueInput uniqueId,
        FlightDealsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.FlightDealsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .FlightDealsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.FlightDealsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple FlightDealsItems records for Packages
    /// </summary>
    public async Task<List<FlightDeals>> FindFlightDealsItems(
        PackagesWhereUniqueInput uniqueId,
        FlightDealsFindManyArgs packagesFindManyArgs
    )
    {
        var flightDealsItems = await _context
            .FlightDealsItems.Where(m => m.PackageFieldId == uniqueId.Id)
            .ApplyWhere(packagesFindManyArgs.Where)
            .ApplySkip(packagesFindManyArgs.Skip)
            .ApplyTake(packagesFindManyArgs.Take)
            .ApplyOrderBy(packagesFindManyArgs.SortBy)
            .ToListAsync();

        return flightDealsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple FlightDealsItems records for Packages
    /// </summary>
    public async Task UpdateFlightDealsItems(
        PackagesWhereUniqueInput uniqueId,
        FlightDealsWhereUniqueInput[] childrenIds
    )
    {
        var packages = await _context
            .PackagesItems.Include(t => t.FlightDealsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (packages == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .FlightDealsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        packages.FlightDealsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple HotelDealsItems records to Packages
    /// </summary>
    public async Task ConnectHotelDealsItems(
        PackagesWhereUniqueInput uniqueId,
        HotelDealsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.HotelDealsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .HotelDealsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.HotelDealsItems);

        foreach (var child in childrenToConnect)
        {
            parent.HotelDealsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple HotelDealsItems records from Packages
    /// </summary>
    public async Task DisconnectHotelDealsItems(
        PackagesWhereUniqueInput uniqueId,
        HotelDealsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.HotelDealsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .HotelDealsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.HotelDealsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple HotelDealsItems records for Packages
    /// </summary>
    public async Task<List<HotelDeals>> FindHotelDealsItems(
        PackagesWhereUniqueInput uniqueId,
        HotelDealsFindManyArgs packagesFindManyArgs
    )
    {
        var hotelDealsItems = await _context
            .HotelDealsItems.Where(m => m.PackageFieldId == uniqueId.Id)
            .ApplyWhere(packagesFindManyArgs.Where)
            .ApplySkip(packagesFindManyArgs.Skip)
            .ApplyTake(packagesFindManyArgs.Take)
            .ApplyOrderBy(packagesFindManyArgs.SortBy)
            .ToListAsync();

        return hotelDealsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple HotelDealsItems records for Packages
    /// </summary>
    public async Task UpdateHotelDealsItems(
        PackagesWhereUniqueInput uniqueId,
        HotelDealsWhereUniqueInput[] childrenIds
    )
    {
        var packages = await _context
            .PackagesItems.Include(t => t.HotelDealsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (packages == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .HotelDealsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        packages.HotelDealsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple PackageFlightsItems records to Packages
    /// </summary>
    public async Task ConnectPackageFlightsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageFlightsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.PackageFlightsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PackageFlightsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.PackageFlightsItems);

        foreach (var child in childrenToConnect)
        {
            parent.PackageFlightsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple PackageFlightsItems records from Packages
    /// </summary>
    public async Task DisconnectPackageFlightsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageFlightsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.PackageFlightsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PackageFlightsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.PackageFlightsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple PackageFlightsItems records for Packages
    /// </summary>
    public async Task<List<PackageFlights>> FindPackageFlightsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageFlightsFindManyArgs packagesFindManyArgs
    )
    {
        var packageFlightsItems = await _context
            .PackageFlightsItems.Where(m => m.PackageFieldId == uniqueId.Id)
            .ApplyWhere(packagesFindManyArgs.Where)
            .ApplySkip(packagesFindManyArgs.Skip)
            .ApplyTake(packagesFindManyArgs.Take)
            .ApplyOrderBy(packagesFindManyArgs.SortBy)
            .ToListAsync();

        return packageFlightsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple PackageFlightsItems records for Packages
    /// </summary>
    public async Task UpdatePackageFlightsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageFlightsWhereUniqueInput[] childrenIds
    )
    {
        var packages = await _context
            .PackagesItems.Include(t => t.PackageFlightsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (packages == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PackageFlightsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        packages.PackageFlightsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple PackageHotelsItems records to Packages
    /// </summary>
    public async Task ConnectPackageHotelsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageHotelsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.PackageHotelsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PackageHotelsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.PackageHotelsItems);

        foreach (var child in childrenToConnect)
        {
            parent.PackageHotelsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple PackageHotelsItems records from Packages
    /// </summary>
    public async Task DisconnectPackageHotelsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageHotelsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.PackageHotelsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PackageHotelsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.PackageHotelsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple PackageHotelsItems records for Packages
    /// </summary>
    public async Task<List<PackageHotels>> FindPackageHotelsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageHotelsFindManyArgs packagesFindManyArgs
    )
    {
        var packageHotelsItems = await _context
            .PackageHotelsItems.Where(m => m.PackageFieldId == uniqueId.Id)
            .ApplyWhere(packagesFindManyArgs.Where)
            .ApplySkip(packagesFindManyArgs.Skip)
            .ApplyTake(packagesFindManyArgs.Take)
            .ApplyOrderBy(packagesFindManyArgs.SortBy)
            .ToListAsync();

        return packageHotelsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple PackageHotelsItems records for Packages
    /// </summary>
    public async Task UpdatePackageHotelsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageHotelsWhereUniqueInput[] childrenIds
    )
    {
        var packages = await _context
            .PackagesItems.Include(t => t.PackageHotelsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (packages == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PackageHotelsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        packages.PackageHotelsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple SightSeeingsItems records to Packages
    /// </summary>
    public async Task ConnectSightSeeingsItems(
        PackagesWhereUniqueInput uniqueId,
        SightSeeingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.SightSeeingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .SightSeeingsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.SightSeeingsItems);

        foreach (var child in childrenToConnect)
        {
            parent.SightSeeingsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple SightSeeingsItems records from Packages
    /// </summary>
    public async Task DisconnectSightSeeingsItems(
        PackagesWhereUniqueInput uniqueId,
        SightSeeingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.SightSeeingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .SightSeeingsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.SightSeeingsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple SightSeeingsItems records for Packages
    /// </summary>
    public async Task<List<SightSeeings>> FindSightSeeingsItems(
        PackagesWhereUniqueInput uniqueId,
        SightSeeingsFindManyArgs packagesFindManyArgs
    )
    {
        var sightSeeingsItems = await _context
            .SightSeeingsItems.Where(m => m.PackageFieldId == uniqueId.Id)
            .ApplyWhere(packagesFindManyArgs.Where)
            .ApplySkip(packagesFindManyArgs.Skip)
            .ApplyTake(packagesFindManyArgs.Take)
            .ApplyOrderBy(packagesFindManyArgs.SortBy)
            .ToListAsync();

        return sightSeeingsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple SightSeeingsItems records for Packages
    /// </summary>
    public async Task UpdateSightSeeingsItems(
        PackagesWhereUniqueInput uniqueId,
        SightSeeingsWhereUniqueInput[] childrenIds
    )
    {
        var packages = await _context
            .PackagesItems.Include(t => t.SightSeeingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (packages == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .SightSeeingsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        packages.SightSeeingsItems = children;
        await _context.SaveChangesAsync();
    }
}
