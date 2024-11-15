using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class MarkdownsServiceBase : IMarkdownsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public MarkdownsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Markdowns
    /// </summary>
    public async Task<Markdowns> CreateMarkdowns(MarkdownCreateInput createDto)
    {
        var markdowns = new MarkdownsDbModel
        {
            AirlineCode = createDto.AirlineCode,
            CreatedAt = createDto.CreatedAt,
            TypeField = createDto.TypeField,
            UpdatedAt = createDto.UpdatedAt,
            Value = createDto.Value
        };

        if (createDto.Id != null)
        {
            markdowns.Id = createDto.Id;
        }

        _context.MarkdownsItems.Add(markdowns);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<MarkdownsDbModel>(markdowns.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Markdowns
    /// </summary>
    public async Task DeleteMarkdowns(MarkdownsWhereUniqueInput uniqueId)
    {
        var markdowns = await _context.MarkdownsItems.FindAsync(uniqueId.Id);
        if (markdowns == null)
        {
            throw new NotFoundException();
        }

        _context.MarkdownsItems.Remove(markdowns);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many MarkdownsItems
    /// </summary>
    public async Task<List<Markdowns>> MarkdownsItems(MarkdownFindManyArgs findManyArgs)
    {
        var markdownsItems = await _context
            .MarkdownsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return markdownsItems.ConvertAll(markdowns => markdowns.ToDto());
    }

    /// <summary>
    /// Meta data about Markdowns records
    /// </summary>
    public async Task<MetadataDto> MarkdownsItemsMeta(MarkdownFindManyArgs findManyArgs)
    {
        var count = await _context.MarkdownsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Markdowns
    /// </summary>
    public async Task<Markdowns> Markdowns(MarkdownsWhereUniqueInput uniqueId)
    {
        var markdownsItems = await this.MarkdownsItems(
            new MarkdownFindManyArgs { Where = new MarkdownWhereInput { Id = uniqueId.Id } }
        );
        var markdowns = markdownsItems.FirstOrDefault();
        if (markdowns == null)
        {
            throw new NotFoundException();
        }

        return markdowns;
    }

    /// <summary>
    /// Update one Markdowns
    /// </summary>
    public async Task UpdateMarkdowns(
        MarkdownsWhereUniqueInput uniqueId,
        MarkdownUpdateInput updateDto
    )
    {
        var markdowns = updateDto.ToModel(uniqueId);

        _context.Entry(markdowns).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.MarkdownsItems.Any(e => e.Id == markdowns.Id))
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
