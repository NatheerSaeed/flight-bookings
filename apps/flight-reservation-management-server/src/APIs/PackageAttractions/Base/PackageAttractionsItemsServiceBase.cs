using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class PackageAttractionsServiceBase : IPackageAttractionsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public PackageAttractionsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one PackageAttractions
    /// </summary>
    public async Task<PackageAttractions> CreatePackageAttractions(
        PackageAttractionCreateInput createDto
    )
    {
        var packageAttractions = new PackageAttraction
        {
            Address = createDto.Address,
            AttractionName = createDto.AttractionName,
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            packageAttractions.Id = createDto.Id;
        }
        if (createDto.PackageField != null)
        {
            packageAttractions.PackageField = await _context
                .PackagesItems.Where(packages => createDto.PackageField.Id == packages.Id)
                .FirstOrDefaultAsync();
        }

        _context.PackageAttractionsItems.Add(packageAttractions);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PackageAttraction>(packageAttractions.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one PackageAttractions
    /// </summary>
    public async Task DeletePackageAttractions(PackageAttractionsWhereUniqueInput uniqueId)
    {
        var packageAttractions = await _context.PackageAttractionsItems.FindAsync(uniqueId.Id);
        if (packageAttractions == null)
        {
            throw new NotFoundException();
        }

        _context.PackageAttractionsItems.Remove(packageAttractions);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many PackageAttractionsItems
    /// </summary>
    public async Task<List<PackageAttractions>> PackageAttractionsItems(
        PackageAttractionFindManyArgs findManyArgs
    )
    {
        var packageAttractionsItems = await _context
            .PackageAttractionsItems.Include(x => x.PackageField)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return packageAttractionsItems.ConvertAll(packageAttractions => packageAttractions.ToDto());
    }

    /// <summary>
    /// Meta data about PackageAttractions records
    /// </summary>
    public async Task<MetadataDto> PackageAttractionsItemsMeta(
        PackageAttractionFindManyArgs findManyArgs
    )
    {
        var count = await _context
            .PackageAttractionsItems.ApplyWhere(findManyArgs.Where)
            .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one PackageAttractions
    /// </summary>
    public async Task<PackageAttractions> PackageAttractions(
        PackageAttractionsWhereUniqueInput uniqueId
    )
    {
        var packageAttractionsItems = await this.PackageAttractionsItems(
            new PackageAttractionFindManyArgs
            {
                Where = new PackageAttractionWhereInput { Id = uniqueId.Id }
            }
        );
        var packageAttractions = packageAttractionsItems.FirstOrDefault();
        if (packageAttractions == null)
        {
            throw new NotFoundException();
        }

        return packageAttractions;
    }

    /// <summary>
    /// Update one PackageAttractions
    /// </summary>
    public async Task UpdatePackageAttractions(
        PackageAttractionsWhereUniqueInput uniqueId,
        PackageAttractionUpdateInput updateDto
    )
    {
        var packageAttractions = updateDto.ToModel(uniqueId);

        if (updateDto.PackageField != null)
        {
            packageAttractions.PackageField = await _context
                .PackagesItems.Where(packages => updateDto.PackageField == packages.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(packageAttractions).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PackageAttractionsItems.Any(e => e.Id == packageAttractions.Id))
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
    /// Get a package_ record for PackageAttractions
    /// </summary>
    public async Task<Packages> GetPackageField(PackageAttractionsWhereUniqueInput uniqueId)
    {
        var packageAttractions = await _context
            .PackageAttractionsItems.Where(packageAttractions =>
                packageAttractions.Id == uniqueId.Id
            )
            .Include(packageAttractions => packageAttractions.PackageField)
            .FirstOrDefaultAsync();
        if (packageAttractions == null)
        {
            throw new NotFoundException();
        }
        return packageAttractions.PackageField.ToDto();
    }
}
