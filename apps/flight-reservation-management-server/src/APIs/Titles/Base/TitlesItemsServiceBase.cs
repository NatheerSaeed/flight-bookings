using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class TitlesItemsServiceBase : ITitlesItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public TitlesItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Titles
    /// </summary>
    public async Task<Titles> CreateTitles(TitlesCreateInput createDto)
    {
        var titles = new TitlesDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            titles.Id = createDto.Id;
        }
        if (createDto.ProfilesItems != null)
        {
            titles.ProfilesItems = await _context
                .ProfilesItems.Where(profiles =>
                    createDto.ProfilesItems.Select(t => t.Id).Contains(profiles.Id)
                )
                .ToListAsync();
        }

        _context.TitlesItems.Add(titles);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TitlesDbModel>(titles.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Titles
    /// </summary>
    public async Task DeleteTitles(TitlesWhereUniqueInput uniqueId)
    {
        var titles = await _context.TitlesItems.FindAsync(uniqueId.Id);
        if (titles == null)
        {
            throw new NotFoundException();
        }

        _context.TitlesItems.Remove(titles);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many TitlesItems
    /// </summary>
    public async Task<List<Titles>> TitlesItems(TitlesFindManyArgs findManyArgs)
    {
        var titlesItems = await _context
            .TitlesItems.Include(x => x.ProfilesItems)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return titlesItems.ConvertAll(titles => titles.ToDto());
    }

    /// <summary>
    /// Meta data about Titles records
    /// </summary>
    public async Task<MetadataDto> TitlesItemsMeta(TitlesFindManyArgs findManyArgs)
    {
        var count = await _context.TitlesItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Titles
    /// </summary>
    public async Task<Titles> Titles(TitlesWhereUniqueInput uniqueId)
    {
        var titlesItems = await this.TitlesItems(
            new TitlesFindManyArgs { Where = new TitlesWhereInput { Id = uniqueId.Id } }
        );
        var titles = titlesItems.FirstOrDefault();
        if (titles == null)
        {
            throw new NotFoundException();
        }

        return titles;
    }

    /// <summary>
    /// Update one Titles
    /// </summary>
    public async Task UpdateTitles(TitlesWhereUniqueInput uniqueId, TitlesUpdateInput updateDto)
    {
        var titles = updateDto.ToModel(uniqueId);

        if (updateDto.ProfilesItems != null)
        {
            titles.ProfilesItems = await _context
                .ProfilesItems.Where(profiles =>
                    updateDto.ProfilesItems.Select(t => t).Contains(profiles.Id)
                )
                .ToListAsync();
        }

        _context.Entry(titles).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.TitlesItems.Any(e => e.Id == titles.Id))
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
    /// Connect multiple ProfilesItems records to Titles
    /// </summary>
    public async Task ConnectProfilesItems(
        TitlesWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .TitlesItems.Include(x => x.ProfilesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ProfilesItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.ProfilesItems);

        foreach (var child in childrenToConnect)
        {
            parent.ProfilesItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple ProfilesItems records from Titles
    /// </summary>
    public async Task DisconnectProfilesItems(
        TitlesWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .TitlesItems.Include(x => x.ProfilesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ProfilesItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.ProfilesItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple ProfilesItems records for Titles
    /// </summary>
    public async Task<List<Profiles>> FindProfilesItems(
        TitlesWhereUniqueInput uniqueId,
        ProfilesFindManyArgs titlesFindManyArgs
    )
    {
        var profilesItems = await _context
            .ProfilesItems.Where(m => m.TitleId == uniqueId.Id)
            .ApplyWhere(titlesFindManyArgs.Where)
            .ApplySkip(titlesFindManyArgs.Skip)
            .ApplyTake(titlesFindManyArgs.Take)
            .ApplyOrderBy(titlesFindManyArgs.SortBy)
            .ToListAsync();

        return profilesItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple ProfilesItems records for Titles
    /// </summary>
    public async Task UpdateProfilesItems(
        TitlesWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] childrenIds
    )
    {
        var titles = await _context
            .TitlesItems.Include(t => t.ProfilesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (titles == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ProfilesItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        titles.ProfilesItems = children;
        await _context.SaveChangesAsync();
    }
}
