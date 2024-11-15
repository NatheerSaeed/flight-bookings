using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class MarkupsServiceBase : IMarkupsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public MarkupsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Markups
    /// </summary>
    public async Task<Markups> CreateMarkups(MarkupCreateInput createDto)
    {
        var markups = new Markup
        {
            CarMarkupType = createDto.CarMarkupType,
            CarMarkupValue = createDto.CarMarkupValue,
            CreatedAt = createDto.CreatedAt,
            FlightMarkupType = createDto.FlightMarkupType,
            FlightMarkupValue = createDto.FlightMarkupValue,
            HotelMarkupType = createDto.HotelMarkupType,
            HotelMarkupValue = createDto.HotelMarkupValue,
            PackageMarkupType = createDto.PackageMarkupType,
            PackageMarkupValue = createDto.PackageMarkupValue,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            markups.Id = createDto.Id;
        }
        if (createDto.Role != null)
        {
            markups.Role = await _context
                .RolesItems.Where(roles => createDto.Role.Id == roles.Id)
                .FirstOrDefaultAsync();
        }

        _context.MarkupsItems.Add(markups);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Markup>(markups.Id);

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
    public async Task<List<Markups>> MarkupsItems(MarkupFindManyArgs findManyArgs)
    {
        var markupsItems = await _context
            .MarkupsItems.Include(x => x.Role)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return markupsItems.ConvertAll(markups => markups.ToDto());
    }

    /// <summary>
    /// Meta data about Markups records
    /// </summary>
    public async Task<MetadataDto> MarkupsItemsMeta(MarkupFindManyArgs findManyArgs)
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
            new MarkupFindManyArgs { Where = new MarkupWhereInput { Id = uniqueId.Id } }
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
    public async Task UpdateMarkups(MarkupsWhereUniqueInput uniqueId, MarkupUpdateInput updateDto)
    {
        var markups = updateDto.ToModel(uniqueId);

        if (updateDto.Role != null)
        {
            markups.Role = await _context
                .RolesItems.Where(roles => updateDto.Role == roles.Id)
                .FirstOrDefaultAsync();
        }

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

    /// <summary>
    /// Get a role_ record for Markups
    /// </summary>
    public async Task<Roles> GetRole(MarkupsWhereUniqueInput uniqueId)
    {
        var markups = await _context
            .MarkupsItems.Where(markups => markups.Id == uniqueId.Id)
            .Include(markups => markups.Role)
            .FirstOrDefaultAsync();
        if (markups == null)
        {
            throw new NotFoundException();
        }
        return markups.Role.ToDto();
    }
}
