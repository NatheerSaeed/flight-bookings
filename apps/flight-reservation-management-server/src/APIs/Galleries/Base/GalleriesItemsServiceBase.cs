using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class GalleriesServiceBase : IGalleriesService
{
    protected readonly FlightReservationManagementDbContext _context;

    public GalleriesServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Galleries
    /// </summary>
    public async Task<Galleries> CreateGalleries(GallerieCreateInput inputDto)
    {
        var galleries = new Gallerie
        {
            CreatedAt = inputDto.CreatedAt,
            ImagePath = inputDto.ImagePath,
            ImageTypeId = inputDto.ImageTypeId,
            ParentId = inputDto.ParentId,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            galleries.Id = inputDto.Id;
        }
        if (inputDto.PackageField != null)
        {
            galleries.PackageField = await _context
                .PackagesItems.Where(packages => inputDto.PackageField.Id == packages.Id)
                .FirstOrDefaultAsync();
        }

        _context.GalleriesItems.Add(galleries);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Gallerie>(galleries.Id);

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
    public async Task<List<Galleries>> GalleriesItems(GallerieFindManyArgs findManyArgs)
    {
        var galleriesItems = await _context
            .GalleriesItems.Include(x => x.PackageField)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return galleriesItems.ConvertAll(galleries => galleries.ToDto());
    }

    /// <summary>
    /// Meta data about Galleries records
    /// </summary>
    public async Task<MetadataDto> GalleriesItemsMeta(GallerieFindManyArgs findManyArgs)
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
            new GallerieFindManyArgs { Where = new GallerieWhereInput { Id = uniqueId.Id } }
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
        GallerieUpdateInput updateDto
    )
    {
        var galleries = updateDto.ToModel(uniqueId);

        if (updateDto.PackageField != null)
        {
            galleries.PackageField = await _context
                .PackagesItems.Where(packages => updateDto.PackageField == packages.Id)
                .FirstOrDefaultAsync();
        }

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

    /// <summary>
    /// Get a package_ record for Galleries
    /// </summary>
    public async Task<Packages> GetPackageField(GalleriesWhereUniqueInput uniqueId)
    {
        var galleries = await _context
            .GalleriesItems.Where(galleries => galleries.Id == uniqueId.Id)
            .Include(galleries => galleries.PackageField)
            .FirstOrDefaultAsync();
        if (galleries == null)
        {
            throw new NotFoundException();
        }
        return galleries.PackageField.ToDto();
    }
}
