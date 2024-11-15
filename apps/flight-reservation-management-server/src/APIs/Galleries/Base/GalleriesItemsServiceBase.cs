using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class GalleriesItemsServiceBase : IGalleriesItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public GalleriesItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Galleries
    /// </summary>
    public async Task<Galleries> CreateGalleries(GalleriesCreateInput createDto)
    {
        var galleries = new GalleriesDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            galleries.Id = createDto.Id;
        }

        _context.GalleriesItems.Add(galleries);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<GalleriesDbModel>(galleries.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Galleries
    /// </summary>
    public async Task DeleteGalleries(GalleriesWhereUniqueInput uniqueId)
    {
        var galleries = await _context.GalleriesItems.FindAsync(uniqueId.Id);
        if (galleries == null)
        {
            throw new NotFoundException();
        }

        _context.GalleriesItems.Remove(galleries);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many GalleriesItems
    /// </summary>
    public async Task<List<Galleries>> GalleriesItems(GalleriesFindManyArgs findManyArgs)
    {
        var galleriesItems = await _context
            .GalleriesItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return galleriesItems.ConvertAll(galleries => galleries.ToDto());
    }

    /// <summary>
    /// Meta data about Galleries records
    /// </summary>
    public async Task<MetadataDto> GalleriesItemsMeta(GalleriesFindManyArgs findManyArgs)
    {
        var count = await _context.GalleriesItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Galleries
    /// </summary>
    public async Task<Galleries> Galleries(GalleriesWhereUniqueInput uniqueId)
    {
        var galleriesItems = await this.GalleriesItems(
            new GalleriesFindManyArgs { Where = new GalleriesWhereInput { Id = uniqueId.Id } }
        );
        var galleries = galleriesItems.FirstOrDefault();
        if (galleries == null)
        {
            throw new NotFoundException();
        }

        return galleries;
    }

    /// <summary>
    /// Update one Galleries
    /// </summary>
    public async Task UpdateGalleries(
        GalleriesWhereUniqueInput uniqueId,
        GalleriesUpdateInput updateDto
    )
    {
        var galleries = updateDto.ToModel(uniqueId);

        _context.Entry(galleries).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.GalleriesItems.Any(e => e.Id == galleries.Id))
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
