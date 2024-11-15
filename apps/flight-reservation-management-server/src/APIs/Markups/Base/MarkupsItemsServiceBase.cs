using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class MarkupsItemsServiceBase : IMarkupsItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public MarkupsItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Markups
    /// </summary>
    public async Task<Markups> CreateMarkups(MarkupsCreateInput createDto)
    {
        var markups = new MarkupsDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            markups.Id = createDto.Id;
        }

        _context.MarkupsItems.Add(markups);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<MarkupsDbModel>(markups.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Markups
    /// </summary>
    public async Task DeleteMarkups(MarkupsWhereUniqueInput uniqueId)
    {
        var markups = await _context.MarkupsItems.FindAsync(uniqueId.Id);
        if (markups == null)
        {
            throw new NotFoundException();
        }

        _context.MarkupsItems.Remove(markups);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many MarkupsItems
    /// </summary>
    public async Task<List<Markups>> MarkupsItems(MarkupsFindManyArgs findManyArgs)
    {
        var markupsItems = await _context
            .MarkupsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return markupsItems.ConvertAll(markups => markups.ToDto());
    }

    /// <summary>
    /// Meta data about Markups records
    /// </summary>
    public async Task<MetadataDto> MarkupsItemsMeta(MarkupsFindManyArgs findManyArgs)
    {
        var count = await _context.MarkupsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Markups
    /// </summary>
    public async Task<Markups> Markups(MarkupsWhereUniqueInput uniqueId)
    {
        var markupsItems = await this.MarkupsItems(
            new MarkupsFindManyArgs { Where = new MarkupsWhereInput { Id = uniqueId.Id } }
        );
        var markups = markupsItems.FirstOrDefault();
        if (markups == null)
        {
            throw new NotFoundException();
        }

        return markups;
    }

    /// <summary>
    /// Update one Markups
    /// </summary>
    public async Task UpdateMarkups(MarkupsWhereUniqueInput uniqueId, MarkupsUpdateInput updateDto)
    {
        var markups = updateDto.ToModel(uniqueId);

        _context.Entry(markups).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.MarkupsItems.Any(e => e.Id == markups.Id))
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
