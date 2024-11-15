using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class SightSeeingsServiceBase : ISightSeeingsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public SightSeeingsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one SightSeeings
    /// </summary>
    public async Task<SightSeeings> CreateSightSeeings(SightSeeingCreateInput createDto)
    {
        var sightSeeings = new SightSeeingsDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Description = createDto.Description,
            Title = createDto.Title,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            sightSeeings.Id = createDto.Id;
        }
        if (createDto.Attraction != null)
        {
            sightSeeings.Attraction = await _context
                .AttractionsItems.Where(attractions => createDto.Attraction.Id == attractions.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.PackageField != null)
        {
            sightSeeings.PackageField = await _context
                .PackagesItems.Where(packages => createDto.PackageField.Id == packages.Id)
                .FirstOrDefaultAsync();
        }

        _context.SightSeeingsItems.Add(sightSeeings);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<SightSeeingsDbModel>(sightSeeings.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one SightSeeings
    /// </summary>
    public async Task DeleteSightSeeings(SightSeeingsWhereUniqueInput uniqueId)
    {
        var sightSeeings = await _context.SightSeeingsItems.FindAsync(uniqueId.Id);
        if (sightSeeings == null)
        {
            throw new NotFoundException();
        }

        _context.SightSeeingsItems.Remove(sightSeeings);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many SightSeeingsItems
    /// </summary>
    public async Task<List<SightSeeings>> SightSeeingsItems(SightSeeingFindManyArgs findManyArgs)
    {
        var sightSeeingsItems = await _context
            .SightSeeingsItems.Include(x => x.Attraction)
            .Include(x => x.PackageField)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return sightSeeingsItems.ConvertAll(sightSeeings => sightSeeings.ToDto());
    }

    /// <summary>
    /// Meta data about SightSeeings records
    /// </summary>
    public async Task<MetadataDto> SightSeeingsItemsMeta(SightSeeingFindManyArgs findManyArgs)
    {
        var count = await _context.SightSeeingsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one SightSeeings
    /// </summary>
    public async Task<SightSeeings> SightSeeings(SightSeeingsWhereUniqueInput uniqueId)
    {
        var sightSeeingsItems = await this.SightSeeingsItems(
            new SightSeeingFindManyArgs { Where = new SightSeeingWhereInput { Id = uniqueId.Id } }
        );
        var sightSeeings = sightSeeingsItems.FirstOrDefault();
        if (sightSeeings == null)
        {
            throw new NotFoundException();
        }

        return sightSeeings;
    }

    /// <summary>
    /// Update one SightSeeings
    /// </summary>
    public async Task UpdateSightSeeings(
        SightSeeingsWhereUniqueInput uniqueId,
        SightSeeingUpdateInput updateDto
    )
    {
        var sightSeeings = updateDto.ToModel(uniqueId);

        if (updateDto.Attraction != null)
        {
            sightSeeings.Attraction = await _context
                .AttractionsItems.Where(attractions => updateDto.Attraction == attractions.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.PackageField != null)
        {
            sightSeeings.PackageField = await _context
                .PackagesItems.Where(packages => updateDto.PackageField == packages.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(sightSeeings).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.SightSeeingsItems.Any(e => e.Id == sightSeeings.Id))
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
    /// Get a attraction_ record for SightSeeings
    /// </summary>
    public async Task<Attractions> GetAttraction(SightSeeingsWhereUniqueInput uniqueId)
    {
        var sightSeeings = await _context
            .SightSeeingsItems.Where(sightSeeings => sightSeeings.Id == uniqueId.Id)
            .Include(sightSeeings => sightSeeings.Attraction)
            .FirstOrDefaultAsync();
        if (sightSeeings == null)
        {
            throw new NotFoundException();
        }
        return sightSeeings.Attraction.ToDto();
    }

    /// <summary>
    /// Get a package_ record for SightSeeings
    /// </summary>
    public async Task<Packages> GetPackageField(SightSeeingsWhereUniqueInput uniqueId)
    {
        var sightSeeings = await _context
            .SightSeeingsItems.Where(sightSeeings => sightSeeings.Id == uniqueId.Id)
            .Include(sightSeeings => sightSeeings.PackageField)
            .FirstOrDefaultAsync();
        if (sightSeeings == null)
        {
            throw new NotFoundException();
        }
        return sightSeeings.PackageField.ToDto();
    }
}
