using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class PackageHotelsItemsServiceBase : IPackageHotelsItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public PackageHotelsItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one PackageHotels
    /// </summary>
    public async Task<PackageHotels> CreatePackageHotels(PackageHotelsCreateInput createDto)
    {
        var packageHotels = new PackageHotelsDbModel
        {
            Address = createDto.Address,
            CreatedAt = createDto.CreatedAt,
            GalleryId = createDto.GalleryId,
            HotelInfo = createDto.HotelInfo,
            HotelLocation = createDto.HotelLocation,
            HotelName = createDto.HotelName,
            HotelStarRating = createDto.HotelStarRating,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            packageHotels.Id = createDto.Id;
        }
        if (createDto.PackageField != null)
        {
            packageHotels.PackageField = await _context
                .PackagesItems.Where(packages => createDto.PackageField.Id == packages.Id)
                .FirstOrDefaultAsync();
        }

        _context.PackageHotelsItems.Add(packageHotels);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PackageHotelsDbModel>(packageHotels.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one PackageHotels
    /// </summary>
    public async Task DeletePackageHotels(PackageHotelsWhereUniqueInput uniqueId)
    {
        var packageHotels = await _context.PackageHotelsItems.FindAsync(uniqueId.Id);
        if (packageHotels == null)
        {
            throw new NotFoundException();
        }

        _context.PackageHotelsItems.Remove(packageHotels);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many PackageHotelsItems
    /// </summary>
    public async Task<List<PackageHotels>> PackageHotelsItems(
        PackageHotelsFindManyArgs findManyArgs
    )
    {
        var packageHotelsItems = await _context
            .PackageHotelsItems.Include(x => x.PackageField)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return packageHotelsItems.ConvertAll(packageHotels => packageHotels.ToDto());
    }

    /// <summary>
    /// Meta data about PackageHotels records
    /// </summary>
    public async Task<MetadataDto> PackageHotelsItemsMeta(PackageHotelsFindManyArgs findManyArgs)
    {
        var count = await _context.PackageHotelsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one PackageHotels
    /// </summary>
    public async Task<PackageHotels> PackageHotels(PackageHotelsWhereUniqueInput uniqueId)
    {
        var packageHotelsItems = await this.PackageHotelsItems(
            new PackageHotelsFindManyArgs
            {
                Where = new PackageHotelsWhereInput { Id = uniqueId.Id }
            }
        );
        var packageHotels = packageHotelsItems.FirstOrDefault();
        if (packageHotels == null)
        {
            throw new NotFoundException();
        }

        return packageHotels;
    }

    /// <summary>
    /// Update one PackageHotels
    /// </summary>
    public async Task UpdatePackageHotels(
        PackageHotelsWhereUniqueInput uniqueId,
        PackageHotelsUpdateInput updateDto
    )
    {
        var packageHotels = updateDto.ToModel(uniqueId);

        if (updateDto.PackageField != null)
        {
            packageHotels.PackageField = await _context
                .PackagesItems.Where(packages => updateDto.PackageField == packages.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(packageHotels).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PackageHotelsItems.Any(e => e.Id == packageHotels.Id))
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
    /// Get a package_ record for PackageHotels
    /// </summary>
    public async Task<Packages> GetPackageField(PackageHotelsWhereUniqueInput uniqueId)
    {
        var packageHotels = await _context
            .PackageHotelsItems.Where(packageHotels => packageHotels.Id == uniqueId.Id)
            .Include(packageHotels => packageHotels.PackageField)
            .FirstOrDefaultAsync();
        if (packageHotels == null)
        {
            throw new NotFoundException();
        }
        return packageHotels.PackageField.ToDto();
    }
}
