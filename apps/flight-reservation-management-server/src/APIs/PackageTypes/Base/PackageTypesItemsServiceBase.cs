using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class PackageTypesServiceBase : IPackageTypesService
{
    protected readonly FlightReservationManagementDbContext _context;

    public PackageTypesServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one PackageTypes
    /// </summary>
    public async Task<PackageTypes> CreatePackageType(PackageTypeCreateInput inputDto)
    {
        var packageTypes = new PackageType
        {
            CreatedAt = inputDto.CreatedAt,
            Status = inputDto.Status,
            TypeField = inputDto.TypeField,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            packageTypes.Id = inputDto.Id;
        }

        _context.PackageTypesItems.Add(packageTypes);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PackageType>(packageTypes.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one PackageTypes
    /// </summary>
    public async Task DeletePackageType(PackageTypesWhereUniqueInput uniqueId)
    {
        var packageTypes = await _context.PackageTypesItems.FindAsync(uniqueId.Id);
        if (packageTypes == null)
        {
            throw new NotFoundException();
        }

        _context.PackageTypesItems.Remove(packageTypes);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many PackageTypesItems
    /// </summary>
    public async Task<List<PackageTypes>> PackageTypesSearchAsync(
        PackageTypeFindManyArgs findManyArgs
    )
    {
        var packageTypesItems = await _context
            .PackageTypesItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return packageTypesItems.ConvertAll(packageTypes => packageTypes.ToDto());
    }

    /// <summary>
    /// Meta data about PackageTypes records
    /// </summary>
    public async Task<MetadataDto> PackageTypesItemsMeta(PackageTypeFindManyArgs findManyArgs)
    {
        var count = await _context.PackageTypesItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one PackageTypes
    /// </summary>
    public async Task<PackageTypes> PackageTypes(PackageTypesWhereUniqueInput uniqueId)
    {
        var packageTypesItems = await this.PackageTypesSearchAsync(
            new PackageTypeFindManyArgs { Where = new PackageTypeWhereInput { Id = uniqueId.Id } }
        );
        var packageTypes = packageTypesItems.FirstOrDefault();
        if (packageTypes == null)
        {
            throw new NotFoundException();
        }

        return packageTypes;
    }

    /// <summary>
    /// Update one PackageTypes
    /// </summary>
    public async Task UpdatePackageType(
        PackageTypesWhereUniqueInput uniqueId,
        PackageTypeUpdateInput updateDto
    )
    {
        var packageTypes = updateDto.ToModel(uniqueId);

        _context.Entry(packageTypes).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PackageTypesItems.Any(e => e.Id == packageTypes.Id))
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
