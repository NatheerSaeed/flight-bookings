using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class AttractionsServiceBase : IAttractionsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public AttractionsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Attractions
    /// </summary>
    public async Task<Attractions> CreateAttraction(AttractionCreateInput inputDto)
    {
        var attractions = new Attraction
        {
            Address = inputDto.Address,
            City = inputDto.City,
            CreatedAt = inputDto.CreatedAt,
            Date = inputDto.Date,
            Information = inputDto.Information,
            Name = inputDto.Name,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            attractions.Id = inputDto.Id;
        }
        if (inputDto.PackageField != null)
        {
            attractions.PackageField = await _context
                .PackagesItems.Where(packages => inputDto.PackageField.Id == packages.Id)
                .FirstOrDefaultAsync();
        }

        if (inputDto.SightSeeingsItems != null)
        {
            attractions.SightSeeingsItems = await _context
                .SightSeeingsItems.Where(sightSeeings =>
                    inputDto.SightSeeingsItems.Select(t => t.Id).Contains(sightSeeings.Id)
                )
                .ToListAsync();
        }

        _context.AttractionsItems.Add(attractions);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Attraction>(attractions.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Attractions
    /// </summary>
    public async Task DeleteAttraction(AttractionsWhereUniqueInput uniqueId)
    {
        var attractions = await _context.AttractionsItems.FindAsync(uniqueId.Id);
        if (attractions == null)
        {
            throw new NotFoundException();
        }

        _context.AttractionsItems.Remove(attractions);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many AttractionsItems
    /// </summary>
    public async Task<List<Attractions>> AttractionsSearchAsync(AttractionFindManyArgs findManyArgs)
    {
        var attractionsItems = await _context
            .AttractionsItems.Include(x => x.SightSeeingsItems)
            .Include(x => x.PackageField)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return attractionsItems.ConvertAll(attractions => attractions.ToDto());
    }

    /// <summary>
    /// Meta data about Attractions records
    /// </summary>
    public async Task<MetadataDto> AttractionsItemsMeta(AttractionFindManyArgs findManyArgs)
    {
        var count = await _context.AttractionsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Attractions
    /// </summary>
    public async Task<Attractions> Attractions(AttractionsWhereUniqueInput uniqueId)
    {
        var attractionsItems = await this.AttractionsSearchAsync(
            new AttractionFindManyArgs { Where = new AttractionWhereInput { Id = uniqueId.Id } }
        );
        var attractions = attractionsItems.FirstOrDefault();
        if (attractions == null)
        {
            throw new NotFoundException();
        }

        return attractions;
    }

    /// <summary>
    /// Update one Attractions
    /// </summary>
    public async Task UpdateAttraction(
        AttractionsWhereUniqueInput uniqueId,
        AttractionUpdateInput updateDto
    )
    {
        var attractions = updateDto.ToModel(uniqueId);

        if (updateDto.PackageField != null)
        {
            attractions.PackageField = await _context
                .PackagesItems.Where(packages => updateDto.PackageField == packages.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.SightSeeingsItems != null)
        {
            attractions.SightSeeingsItems = await _context
                .SightSeeingsItems.Where(sightSeeings =>
                    updateDto.SightSeeingsItems.Select(t => t).Contains(sightSeeings.Id)
                )
                .ToListAsync();
        }

        _context.Entry(attractions).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.AttractionsItems.Any(e => e.Id == attractions.Id))
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
    /// Get a package_ record for Attractions
    /// </summary>
    public async Task<Packages> GetPackageField(AttractionsWhereUniqueInput uniqueId)
    {
        var attractions = await _context
            .AttractionsItems.Where(attractions => attractions.Id == uniqueId.Id)
            .Include(attractions => attractions.PackageField)
            .FirstOrDefaultAsync();
        if (attractions == null)
        {
            throw new NotFoundException();
        }
        return attractions.PackageField.ToDto();
    }

    /// <summary>
    /// Connect multiple SightSeeingsItems records to Attractions
    /// </summary>
    public async Task ConnectSightSeeingsSearchAsync(
        AttractionsWhereUniqueInput uniqueId,
        SightSeeingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .AttractionsItems.Include(x => x.SightSeeingsItems)
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
    /// Disconnect multiple SightSeeingsItems records from Attractions
    /// </summary>
    public async Task DisconnectSightSeeingsSearchAsync(
        AttractionsWhereUniqueInput uniqueId,
        SightSeeingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .AttractionsItems.Include(x => x.SightSeeingsItems)
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
    /// Find multiple SightSeeingsItems records for Attractions
    /// </summary>
    public async Task<List<SightSeeings>> FindSightSeeingsSearchAsync(
        AttractionsWhereUniqueInput uniqueId,
        SightSeeingFindManyArgs attractionFindManyArgs
    )
    {
        var sightSeeingsItems = await _context
            .SightSeeingsItems.Where(m => m.AttractionId == uniqueId.Id)
            .ApplyWhere(attractionFindManyArgs.Where)
            .ApplySkip(attractionFindManyArgs.Skip)
            .ApplyTake(attractionFindManyArgs.Take)
            .ApplyOrderBy(attractionFindManyArgs.SortBy)
            .ToListAsync();

        return sightSeeingsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple SightSeeingsItems records for Attractions
    /// </summary>
    public async Task UpdateSightSeeingsItem(
        AttractionsWhereUniqueInput uniqueId,
        SightSeeingsWhereUniqueInput[] childrenIds
    )
    {
        var attractions = await _context
            .AttractionsItems.Include(t => t.SightSeeingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (attractions == null)
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

        attractions.SightSeeingsItems = children;
        await _context.SaveChangesAsync();
    }
}
