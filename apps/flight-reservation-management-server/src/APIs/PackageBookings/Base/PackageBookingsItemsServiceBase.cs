using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class PackageBookingsItemsServiceBase : IPackageBookingsItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public PackageBookingsItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one PackageBookings
    /// </summary>
    public async Task<PackageBookings> CreatePackageBookings(PackageBookingsCreateInput createDto)
    {
        var packageBookings = new PackageBookingsDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            packageBookings.Id = createDto.Id;
        }

        _context.PackageBookingsItems.Add(packageBookings);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PackageBookingsDbModel>(packageBookings.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one PackageBookings
    /// </summary>
    public async Task DeletePackageBookings(PackageBookingsWhereUniqueInput uniqueId)
    {
        var packageBookings = await _context.PackageBookingsItems.FindAsync(uniqueId.Id);
        if (packageBookings == null)
        {
            throw new NotFoundException();
        }

        _context.PackageBookingsItems.Remove(packageBookings);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many PackageBookingsItems
    /// </summary>
    public async Task<List<PackageBookings>> PackageBookingsItems(
        PackageBookingsFindManyArgs findManyArgs
    )
    {
        var packageBookingsItems = await _context
            .PackageBookingsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return packageBookingsItems.ConvertAll(packageBookings => packageBookings.ToDto());
    }

    /// <summary>
    /// Meta data about PackageBookings records
    /// </summary>
    public async Task<MetadataDto> PackageBookingsItemsMeta(
        PackageBookingsFindManyArgs findManyArgs
    )
    {
        var count = await _context.PackageBookingsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one PackageBookings
    /// </summary>
    public async Task<PackageBookings> PackageBookings(PackageBookingsWhereUniqueInput uniqueId)
    {
        var packageBookingsItems = await this.PackageBookingsItems(
            new PackageBookingsFindManyArgs
            {
                Where = new PackageBookingsWhereInput { Id = uniqueId.Id }
            }
        );
        var packageBookings = packageBookingsItems.FirstOrDefault();
        if (packageBookings == null)
        {
            throw new NotFoundException();
        }

        return packageBookings;
    }

    /// <summary>
    /// Update one PackageBookings
    /// </summary>
    public async Task UpdatePackageBookings(
        PackageBookingsWhereUniqueInput uniqueId,
        PackageBookingsUpdateInput updateDto
    )
    {
        var packageBookings = updateDto.ToModel(uniqueId);

        _context.Entry(packageBookings).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PackageBookingsItems.Any(e => e.Id == packageBookings.Id))
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
