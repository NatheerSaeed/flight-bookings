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
            Adults = createDto.Adults,
            BookingStatus = createDto.BookingStatus,
            Children = createDto.Children,
            CreatedAt = createDto.CreatedAt,
            CustomerEmail = createDto.CustomerEmail,
            CustomerFirstName = createDto.CustomerFirstName,
            CustomerOtherName = createDto.CustomerOtherName,
            CustomerPhone = createDto.CustomerPhone,
            CustomerSurName = createDto.CustomerSurName,
            CustomerTitleId = createDto.CustomerTitleId,
            Infants = createDto.Infants,
            PaymentStatus = createDto.PaymentStatus,
            Reference = createDto.Reference,
            TotalAmount = createDto.TotalAmount,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            packageBookings.Id = createDto.Id;
        }
        if (createDto.PackageField != null)
        {
            packageBookings.PackageField = await _context
                .PackagesItems.Where(packages => createDto.PackageField.Id == packages.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.User != null)
        {
            packageBookings.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
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
            .PackageBookingsItems.Include(x => x.PackageField)
            .Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
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

        if (updateDto.PackageField != null)
        {
            packageBookings.PackageField = await _context
                .PackagesItems.Where(packages => updateDto.PackageField == packages.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.User != null)
        {
            packageBookings.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

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

    /// <summary>
    /// Get a package_ record for PackageBookings
    /// </summary>
    public async Task<Packages> GetPackageField(PackageBookingsWhereUniqueInput uniqueId)
    {
        var packageBookings = await _context
            .PackageBookingsItems.Where(packageBookings => packageBookings.Id == uniqueId.Id)
            .Include(packageBookings => packageBookings.PackageField)
            .FirstOrDefaultAsync();
        if (packageBookings == null)
        {
            throw new NotFoundException();
        }
        return packageBookings.PackageField.ToDto();
    }

    /// <summary>
    /// Get a user_ record for PackageBookings
    /// </summary>
    public async Task<User> GetUser(PackageBookingsWhereUniqueInput uniqueId)
    {
        var packageBookings = await _context
            .PackageBookingsItems.Where(packageBookings => packageBookings.Id == uniqueId.Id)
            .Include(packageBookings => packageBookings.User)
            .FirstOrDefaultAsync();
        if (packageBookings == null)
        {
            throw new NotFoundException();
        }
        return packageBookings.User.ToDto();
    }
}
