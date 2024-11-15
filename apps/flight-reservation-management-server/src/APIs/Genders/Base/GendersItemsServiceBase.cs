using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class GendersItemsServiceBase : IGendersItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public GendersItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Genders
    /// </summary>
    public async Task<Genders> CreateGenders(GendersCreateInput createDto)
    {
        var genders = new GendersDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            genders.Id = createDto.Id;
        }
        if (createDto.ProfilesItems != null)
        {
            genders.ProfilesItems = await _context
                .ProfilesItems.Where(profiles =>
                    createDto.ProfilesItems.Select(t => t.Id).Contains(profiles.Id)
                )
                .ToListAsync();
        }

        _context.GendersItems.Add(genders);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<GendersDbModel>(genders.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Genders
    /// </summary>
    public async Task DeleteGenders(GendersWhereUniqueInput uniqueId)
    {
        var genders = await _context.GendersItems.FindAsync(uniqueId.Id);
        if (genders == null)
        {
            throw new NotFoundException();
        }

        _context.GendersItems.Remove(genders);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many GendersItems
    /// </summary>
    public async Task<List<Genders>> GendersItems(GendersFindManyArgs findManyArgs)
    {
        var gendersItems = await _context
            .GendersItems.Include(x => x.ProfilesItems)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return gendersItems.ConvertAll(genders => genders.ToDto());
    }

    /// <summary>
    /// Meta data about Genders records
    /// </summary>
    public async Task<MetadataDto> GendersItemsMeta(GendersFindManyArgs findManyArgs)
    {
        var count = await _context.GendersItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Genders
    /// </summary>
    public async Task<Genders> Genders(GendersWhereUniqueInput uniqueId)
    {
        var gendersItems = await this.GendersItems(
            new GendersFindManyArgs { Where = new GendersWhereInput { Id = uniqueId.Id } }
        );
        var genders = gendersItems.FirstOrDefault();
        if (genders == null)
        {
            throw new NotFoundException();
        }

        return genders;
    }

    /// <summary>
    /// Update one Genders
    /// </summary>
    public async Task UpdateGenders(GendersWhereUniqueInput uniqueId, GendersUpdateInput updateDto)
    {
        var genders = updateDto.ToModel(uniqueId);

        if (updateDto.ProfilesItems != null)
        {
            genders.ProfilesItems = await _context
                .ProfilesItems.Where(profiles =>
                    updateDto.ProfilesItems.Select(t => t).Contains(profiles.Id)
                )
                .ToListAsync();
        }

        _context.Entry(genders).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.GendersItems.Any(e => e.Id == genders.Id))
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
    /// Connect multiple ProfilesItems records to Genders
    /// </summary>
    public async Task ConnectProfilesItems(
        GendersWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .GendersItems.Include(x => x.ProfilesItems)
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
    /// Disconnect multiple ProfilesItems records from Genders
    /// </summary>
    public async Task DisconnectProfilesItems(
        GendersWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .GendersItems.Include(x => x.ProfilesItems)
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
    /// Find multiple ProfilesItems records for Genders
    /// </summary>
    public async Task<List<Profiles>> FindProfilesItems(
        GendersWhereUniqueInput uniqueId,
        ProfilesFindManyArgs gendersFindManyArgs
    )
    {
        var profilesItems = await _context
            .ProfilesItems.Where(m => m.GenderId == uniqueId.Id)
            .ApplyWhere(gendersFindManyArgs.Where)
            .ApplySkip(gendersFindManyArgs.Skip)
            .ApplyTake(gendersFindManyArgs.Take)
            .ApplyOrderBy(gendersFindManyArgs.SortBy)
            .ToListAsync();

        return profilesItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple ProfilesItems records for Genders
    /// </summary>
    public async Task UpdateProfilesItems(
        GendersWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] childrenIds
    )
    {
        var genders = await _context
            .GendersItems.Include(t => t.ProfilesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (genders == null)
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

        genders.ProfilesItems = children;
        await _context.SaveChangesAsync();
    }
}
