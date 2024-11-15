using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class PackagesServiceBase : IPackagesService
{
    protected readonly FlightReservationManagementDbContext _context;

    public PackagesServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Packages
    /// </summary>
    public async Task<Packages> CreatePackage(PackageCreateInput inputDto)
    {
        var packages = new Package
        {
            CreatedAt = inputDto.CreatedAt,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            packages.Id = inputDto.Id;
        }
        if (inputDto.AttractionsItems != null)
        {
            packages.AttractionsItems = await _context
                .AttractionsItems.Where(attractions =>
                    inputDto.AttractionsItems.Select(t => t.Id).Contains(attractions.Id)
                )
                .ToListAsync();
        }

        if (inputDto.FlightDealsItems != null)
        {
            packages.FlightDealsItems = await _context
                .FlightDealsItems.Where(flightDeals =>
                    inputDto.FlightDealsItems.Select(t => t.Id).Contains(flightDeals.Id)
                )
                .ToListAsync();
        }

        if (inputDto.GalleriesItems != null)
        {
            packages.GalleriesItems = await _context
                .GalleriesItems.Where(galleries =>
                    inputDto.GalleriesItems.Select(t => t.Id).Contains(galleries.Id)
                )
                .ToListAsync();
        }

        if (inputDto.GoodToKnowsItems != null)
        {
            packages.GoodToKnowsItems = await _context
                .GoodToKnowsItems.Where(goodToKnows =>
                    inputDto.GoodToKnowsItems.Select(t => t.Id).Contains(goodToKnows.Id)
                )
                .ToListAsync();
        }

        if (inputDto.HotelDealsItems != null)
        {
            packages.HotelDealsItems = await _context
                .HotelDealsItems.Where(hotelDeals =>
                    inputDto.HotelDealsItems.Select(t => t.Id).Contains(hotelDeals.Id)
                )
                .ToListAsync();
        }

        if (inputDto.PackageAttractionsItems != null)
        {
            packages.PackageAttractionsItems = await _context
                .PackageAttractionsItems.Where(packageAttractions =>
                    inputDto
                        .PackageAttractionsItems.Select(t => t.Id)
                        .Contains(packageAttractions.Id)
                )
                .ToListAsync();
        }

        if (inputDto.PackageBookingsItems != null)
        {
            packages.PackageBookingsItems = await _context
                .PackageBookingsItems.Where(packageBookings =>
                    inputDto.PackageBookingsItems.Select(t => t.Id).Contains(packageBookings.Id)
                )
                .ToListAsync();
        }

        if (inputDto.PackageFlightsItems != null)
        {
            packages.PackageFlightsItems = await _context
                .PackageFlightsItems.Where(packageFlights =>
                    inputDto.PackageFlightsItems.Select(t => t.Id).Contains(packageFlights.Id)
                )
                .ToListAsync();
        }

        if (inputDto.PackageHotelsItems != null)
        {
            packages.PackageHotelsItems = await _context
                .PackageHotelsItems.Where(packageHotels =>
                    inputDto.PackageHotelsItems.Select(t => t.Id).Contains(packageHotels.Id)
                )
                .ToListAsync();
        }

        if (inputDto.SightSeeingsItems != null)
        {
            packages.SightSeeingsItems = await _context
                .SightSeeingsItems.Where(sightSeeings =>
                    inputDto.SightSeeingsItems.Select(t => t.Id).Contains(sightSeeings.Id)
                )
                .ToListAsync();
        }

        _context.PackagesItems.Add(packages);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Package>(packages.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Packages
    /// </summary>
    public async Task DeletePackage(PackagesWhereUniqueInput uniqueId)
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
    public async Task<List<Packages>> PackagesSearchAsync(PackageFindManyArgs findManyArgs)
    {
        var packagesItems = await _context
            .PackagesItems.Include(x => x.GoodToKnowsItems)
            .Include(x => x.GalleriesItems)
            .Include(x => x.SightSeeingsItems)
            .Include(x => x.PackageHotelsItems)
            .Include(x => x.AttractionsItems)
            .Include(x => x.FlightDealsItems)
            .Include(x => x.HotelDealsItems)
            .Include(x => x.PackageAttractionsItems)
            .Include(x => x.PackageBookingsItems)
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
    public async Task<MetadataDto> PackagesItemsMeta(PackageFindManyArgs findManyArgs)
    {
        var count = await _context.PackagesItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Packages
    /// </summary>
    public async Task<Packages> Packages(PackagesWhereUniqueInput uniqueId)
    {
        var packagesItems = await this.PackagesSearchAsync(
            new PackageFindManyArgs { Where = new PackageWhereInput { Id = uniqueId.Id } }
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
    public async Task UpdatePackage(PackagesWhereUniqueInput uniqueId, PackageUpdateInput updateDto)
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

        if (updateDto.GalleriesItems != null)
        {
            packages.GalleriesItems = await _context
                .GalleriesItems.Where(galleries =>
                    updateDto.GalleriesItems.Select(t => t).Contains(galleries.Id)
                )
                .ToListAsync();
        }

        if (updateDto.GoodToKnowsItems != null)
        {
            packages.GoodToKnowsItems = await _context
                .GoodToKnowsItems.Where(goodToKnows =>
                    updateDto.GoodToKnowsItems.Select(t => t).Contains(goodToKnows.Id)
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

        if (updateDto.PackageAttractionsItems != null)
        {
            packages.PackageAttractionsItems = await _context
                .PackageAttractionsItems.Where(packageAttractions =>
                    updateDto.PackageAttractionsItems.Select(t => t).Contains(packageAttractions.Id)
                )
                .ToListAsync();
        }

        if (updateDto.PackageBookingsItems != null)
        {
            packages.PackageBookingsItems = await _context
                .PackageBookingsItems.Where(packageBookings =>
                    updateDto.PackageBookingsItems.Select(t => t).Contains(packageBookings.Id)
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
    public async Task ConnectAttractionsSearchAsync(
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
    public async Task DisconnectAttractionsSearchAsync(
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
    public async Task<List<Attractions>> FindAttractionsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        AttractionFindManyArgs packageFindManyArgs
    )
    {
        var attractionsItems = await _context
            .AttractionsItems.Where(m => m.PackageFieldId == uniqueId.Id)
            .ApplyWhere(packageFindManyArgs.Where)
            .ApplySkip(packageFindManyArgs.Skip)
            .ApplyTake(packageFindManyArgs.Take)
            .ApplyOrderBy(packageFindManyArgs.SortBy)
            .ToListAsync();

        return attractionsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple AttractionsItems records for Packages
    /// </summary>
    public async Task UpdateAttractionsItem(
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
    public async Task ConnectFlightDealsSearchAsync(
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
    public async Task DisconnectFlightDealsSearchAsync(
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
    public async Task<List<FlightDeals>> FindFlightDealsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        FlightDealFindManyArgs packageFindManyArgs
    )
    {
        var flightDealsItems = await _context
            .FlightDealsItems.Where(m => m.PackageFieldId == uniqueId.Id)
            .ApplyWhere(packageFindManyArgs.Where)
            .ApplySkip(packageFindManyArgs.Skip)
            .ApplyTake(packageFindManyArgs.Take)
            .ApplyOrderBy(packageFindManyArgs.SortBy)
            .ToListAsync();

        return flightDealsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple FlightDealsItems records for Packages
    /// </summary>
    public async Task UpdateFlightDealsItem(
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
    /// Connect multiple GalleriesItems records to Packages
    /// </summary>
    public async Task ConnectGalleriesSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        GalleriesWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.GalleriesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .GalleriesItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.GalleriesItems);

        foreach (var child in childrenToConnect)
        {
            parent.GalleriesItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple GalleriesItems records from Packages
    /// </summary>
    public async Task DisconnectGalleriesSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        GalleriesWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.GalleriesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .GalleriesItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.GalleriesItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple GalleriesItems records for Packages
    /// </summary>
    public async Task<List<Galleries>> FindGalleriesSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        GallerieFindManyArgs packageFindManyArgs
    )
    {
        var galleriesItems = await _context
            .GalleriesItems.Where(m => m.PackageFieldId == uniqueId.Id)
            .ApplyWhere(packageFindManyArgs.Where)
            .ApplySkip(packageFindManyArgs.Skip)
            .ApplyTake(packageFindManyArgs.Take)
            .ApplyOrderBy(packageFindManyArgs.SortBy)
            .ToListAsync();

        return galleriesItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple GalleriesItems records for Packages
    /// </summary>
    public async Task UpdateGalleriesItem(
        PackagesWhereUniqueInput uniqueId,
        GalleriesWhereUniqueInput[] childrenIds
    )
    {
        var packages = await _context
            .PackagesItems.Include(t => t.GalleriesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (packages == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .GalleriesItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        packages.GalleriesItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple GoodToKnowsItems records to Packages
    /// </summary>
    public async Task ConnectGoodToKnowsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        GoodToKnowsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.GoodToKnowsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .GoodToKnowsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.GoodToKnowsItems);

        foreach (var child in childrenToConnect)
        {
            parent.GoodToKnowsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple GoodToKnowsItems records from Packages
    /// </summary>
    public async Task DisconnectGoodToKnowsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        GoodToKnowsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.GoodToKnowsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .GoodToKnowsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.GoodToKnowsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple GoodToKnowsItems records for Packages
    /// </summary>
    public async Task<List<GoodToKnows>> FindGoodToKnowsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        GoodToKnowFindManyArgs packageFindManyArgs
    )
    {
        var goodToKnowsItems = await _context
            .GoodToKnowsItems.Where(m => m.PackageFieldId == uniqueId.Id)
            .ApplyWhere(packageFindManyArgs.Where)
            .ApplySkip(packageFindManyArgs.Skip)
            .ApplyTake(packageFindManyArgs.Take)
            .ApplyOrderBy(packageFindManyArgs.SortBy)
            .ToListAsync();

        return goodToKnowsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple GoodToKnowsItems records for Packages
    /// </summary>
    public async Task UpdateGoodToKnowsItem(
        PackagesWhereUniqueInput uniqueId,
        GoodToKnowsWhereUniqueInput[] childrenIds
    )
    {
        var packages = await _context
            .PackagesItems.Include(t => t.GoodToKnowsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (packages == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .GoodToKnowsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        packages.GoodToKnowsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple HotelDealsItems records to Packages
    /// </summary>
    public async Task ConnectHotelDealsSearchAsync(
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
    public async Task DisconnectHotelDealsSearchAsync(
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
    public async Task<List<HotelDeals>> FindHotelDealsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        HotelDealFindManyArgs packageFindManyArgs
    )
    {
        var hotelDealsItems = await _context
            .HotelDealsItems.Where(m => m.PackageFieldId == uniqueId.Id)
            .ApplyWhere(packageFindManyArgs.Where)
            .ApplySkip(packageFindManyArgs.Skip)
            .ApplyTake(packageFindManyArgs.Take)
            .ApplyOrderBy(packageFindManyArgs.SortBy)
            .ToListAsync();

        return hotelDealsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple HotelDealsItems records for Packages
    /// </summary>
    public async Task UpdateHotelDealsItem(
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
    /// Connect multiple PackageAttractionsItems records to Packages
    /// </summary>
    public async Task ConnectPackageAttractionsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageAttractionsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.PackageAttractionsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PackageAttractionsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.PackageAttractionsItems);

        foreach (var child in childrenToConnect)
        {
            parent.PackageAttractionsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple PackageAttractionsItems records from Packages
    /// </summary>
    public async Task DisconnectPackageAttractionsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageAttractionsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.PackageAttractionsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PackageAttractionsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.PackageAttractionsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple PackageAttractionsItems records for Packages
    /// </summary>
    public async Task<List<PackageAttractions>> FindPackageAttractionsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageAttractionFindManyArgs packageFindManyArgs
    )
    {
        var packageAttractionsItems = await _context
            .PackageAttractionsItems.Where(m => m.PackageFieldId == uniqueId.Id)
            .ApplyWhere(packageFindManyArgs.Where)
            .ApplySkip(packageFindManyArgs.Skip)
            .ApplyTake(packageFindManyArgs.Take)
            .ApplyOrderBy(packageFindManyArgs.SortBy)
            .ToListAsync();

        return packageAttractionsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple PackageAttractionsItems records for Packages
    /// </summary>
    public async Task UpdatePackageAttractionsItem(
        PackagesWhereUniqueInput uniqueId,
        PackageAttractionsWhereUniqueInput[] childrenIds
    )
    {
        var packages = await _context
            .PackagesItems.Include(t => t.PackageAttractionsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (packages == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PackageAttractionsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        packages.PackageAttractionsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple PackageBookingsItems records to Packages
    /// </summary>
    public async Task ConnectPackageBookingsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageBookingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.PackageBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PackageBookingsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.PackageBookingsItems);

        foreach (var child in childrenToConnect)
        {
            parent.PackageBookingsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple PackageBookingsItems records from Packages
    /// </summary>
    public async Task DisconnectPackageBookingsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageBookingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .PackagesItems.Include(x => x.PackageBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PackageBookingsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.PackageBookingsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple PackageBookingsItems records for Packages
    /// </summary>
    public async Task<List<PackageBookings>> FindPackageBookingsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageBookingFindManyArgs packageFindManyArgs
    )
    {
        var packageBookingsItems = await _context
            .PackageBookingsItems.Where(m => m.PackageFieldId == uniqueId.Id)
            .ApplyWhere(packageFindManyArgs.Where)
            .ApplySkip(packageFindManyArgs.Skip)
            .ApplyTake(packageFindManyArgs.Take)
            .ApplyOrderBy(packageFindManyArgs.SortBy)
            .ToListAsync();

        return packageBookingsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple PackageBookingsItems records for Packages
    /// </summary>
    public async Task UpdatePackageBookingsItem(
        PackagesWhereUniqueInput uniqueId,
        PackageBookingsWhereUniqueInput[] childrenIds
    )
    {
        var packages = await _context
            .PackagesItems.Include(t => t.PackageBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (packages == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PackageBookingsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        packages.PackageBookingsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple PackageFlightsItems records to Packages
    /// </summary>
    public async Task ConnectPackageFlightsSearchAsync(
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
    public async Task DisconnectPackageFlightsSearchAsync(
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
    public async Task<List<PackageFlights>> FindPackageFlightsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageFlightFindManyArgs packageFindManyArgs
    )
    {
        var packageFlightsItems = await _context
            .PackageFlightsItems.Where(m => m.PackageFieldId == uniqueId.Id)
            .ApplyWhere(packageFindManyArgs.Where)
            .ApplySkip(packageFindManyArgs.Skip)
            .ApplyTake(packageFindManyArgs.Take)
            .ApplyOrderBy(packageFindManyArgs.SortBy)
            .ToListAsync();

        return packageFlightsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple PackageFlightsItems records for Packages
    /// </summary>
    public async Task UpdatePackageFlightsItem(
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
    public async Task ConnectPackageHotelsSearchAsync(
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
    public async Task DisconnectPackageHotelsSearchAsync(
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
    public async Task<List<PackageHotels>> FindPackageHotelsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageHotelFindManyArgs packageFindManyArgs
    )
    {
        var packageHotelsItems = await _context
            .PackageHotelsItems.Where(m => m.PackageFieldId == uniqueId.Id)
            .ApplyWhere(packageFindManyArgs.Where)
            .ApplySkip(packageFindManyArgs.Skip)
            .ApplyTake(packageFindManyArgs.Take)
            .ApplyOrderBy(packageFindManyArgs.SortBy)
            .ToListAsync();

        return packageHotelsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple PackageHotelsItems records for Packages
    /// </summary>
    public async Task UpdatePackageHotelsItem(
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
    public async Task ConnectSightSeeingsSearchAsync(
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
    public async Task DisconnectSightSeeingsSearchAsync(
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
    public async Task<List<SightSeeings>> FindSightSeeingsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        SightSeeingFindManyArgs packageFindManyArgs
    )
    {
        var sightSeeingsItems = await _context
            .SightSeeingsItems.Where(m => m.PackageFieldId == uniqueId.Id)
            .ApplyWhere(packageFindManyArgs.Where)
            .ApplySkip(packageFindManyArgs.Skip)
            .ApplyTake(packageFindManyArgs.Take)
            .ApplyOrderBy(packageFindManyArgs.SortBy)
            .ToListAsync();

        return sightSeeingsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple SightSeeingsItems records for Packages
    /// </summary>
    public async Task UpdateSightSeeingsItem(
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
