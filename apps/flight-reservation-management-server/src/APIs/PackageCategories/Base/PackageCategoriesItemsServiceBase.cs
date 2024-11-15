using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class PackageCategoriesItemsServiceBase : IPackageCategoriesItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public PackageCategoriesItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one PackageCategories
    /// </summary>
    public async Task<PackageCategories> CreatePackageCategories(
        PackageCategoriesCreateInput createDto
    )
    {
        var packageCategories = new PackageCategoriesDbModel
        {
            Category = createDto.Category,
            CreatedAt = createDto.CreatedAt,
            Status = createDto.Status,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            packageCategories.Id = createDto.Id;
        }

        _context.PackageCategoriesItems.Add(packageCategories);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PackageCategoriesDbModel>(packageCategories.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one PackageCategories
    /// </summary>
    public async Task DeletePackageCategories(PackageCategoriesWhereUniqueInput uniqueId)
    {
        var packageCategories = await _context.PackageCategoriesItems.FindAsync(uniqueId.Id);
        if (packageCategories == null)
        {
            throw new NotFoundException();
        }

        _context.PackageCategoriesItems.Remove(packageCategories);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many PackageCategoriesItems
    /// </summary>
    public async Task<List<PackageCategories>> PackageCategoriesItems(
        PackageCategoriesFindManyArgs findManyArgs
    )
    {
        var packageCategoriesItems = await _context
            .PackageCategoriesItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return packageCategoriesItems.ConvertAll(packageCategories => packageCategories.ToDto());
    }

    /// <summary>
    /// Meta data about PackageCategories records
    /// </summary>
    public async Task<MetadataDto> PackageCategoriesItemsMeta(
        PackageCategoriesFindManyArgs findManyArgs
    )
    {
        var count = await _context
            .PackageCategoriesItems.ApplyWhere(findManyArgs.Where)
            .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one PackageCategories
    /// </summary>
    public async Task<PackageCategories> PackageCategories(
        PackageCategoriesWhereUniqueInput uniqueId
    )
    {
        var packageCategoriesItems = await this.PackageCategoriesItems(
            new PackageCategoriesFindManyArgs
            {
                Where = new PackageCategoriesWhereInput { Id = uniqueId.Id }
            }
        );
        var packageCategories = packageCategoriesItems.FirstOrDefault();
        if (packageCategories == null)
        {
            throw new NotFoundException();
        }

        return packageCategories;
    }

    /// <summary>
    /// Update one PackageCategories
    /// </summary>
    public async Task UpdatePackageCategories(
        PackageCategoriesWhereUniqueInput uniqueId,
        PackageCategoriesUpdateInput updateDto
    )
    {
        var packageCategories = updateDto.ToModel(uniqueId);

        _context.Entry(packageCategories).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PackageCategoriesItems.Any(e => e.Id == packageCategories.Id))
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
