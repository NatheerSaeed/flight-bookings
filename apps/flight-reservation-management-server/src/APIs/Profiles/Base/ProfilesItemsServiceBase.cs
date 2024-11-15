using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class ProfilesItemsServiceBase : IProfilesItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public ProfilesItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Profiles
    /// </summary>
    public async Task<Profiles> CreateProfiles(ProfilesCreateInput createDto)
    {
        var profiles = new ProfilesDbModel
        {
            Address = createDto.Address,
            CreatedAt = createDto.CreatedAt,
            FirstName = createDto.FirstName,
            OtherName = createDto.OtherName,
            PhoneNumber = createDto.PhoneNumber,
            Photo = createDto.Photo,
            SurName = createDto.SurName,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            profiles.Id = createDto.Id;
        }
        if (createDto.Gender != null)
        {
            profiles.Gender = await _context
                .GendersItems.Where(genders => createDto.Gender.Id == genders.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Title != null)
        {
            profiles.Title = await _context
                .TitlesItems.Where(titles => createDto.Title.Id == titles.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.User != null)
        {
            profiles.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.ProfilesItems.Add(profiles);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ProfilesDbModel>(profiles.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Profiles
    /// </summary>
    public async Task DeleteProfiles(ProfilesWhereUniqueInput uniqueId)
    {
        var profiles = await _context.ProfilesItems.FindAsync(uniqueId.Id);
        if (profiles == null)
        {
            throw new NotFoundException();
        }

        _context.ProfilesItems.Remove(profiles);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ProfilesItems
    /// </summary>
    public async Task<List<Profiles>> ProfilesItems(ProfilesFindManyArgs findManyArgs)
    {
        var profilesItems = await _context
            .ProfilesItems.Include(x => x.Gender)
            .Include(x => x.Title)
            .Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return profilesItems.ConvertAll(profiles => profiles.ToDto());
    }

    /// <summary>
    /// Meta data about Profiles records
    /// </summary>
    public async Task<MetadataDto> ProfilesItemsMeta(ProfilesFindManyArgs findManyArgs)
    {
        var count = await _context.ProfilesItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Profiles
    /// </summary>
    public async Task<Profiles> Profiles(ProfilesWhereUniqueInput uniqueId)
    {
        var profilesItems = await this.ProfilesItems(
            new ProfilesFindManyArgs { Where = new ProfilesWhereInput { Id = uniqueId.Id } }
        );
        var profiles = profilesItems.FirstOrDefault();
        if (profiles == null)
        {
            throw new NotFoundException();
        }

        return profiles;
    }

    /// <summary>
    /// Update one Profiles
    /// </summary>
    public async Task UpdateProfiles(
        ProfilesWhereUniqueInput uniqueId,
        ProfilesUpdateInput updateDto
    )
    {
        var profiles = updateDto.ToModel(uniqueId);

        if (updateDto.Gender != null)
        {
            profiles.Gender = await _context
                .GendersItems.Where(genders => updateDto.Gender == genders.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.Title != null)
        {
            profiles.Title = await _context
                .TitlesItems.Where(titles => updateDto.Title == titles.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.User != null)
        {
            profiles.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(profiles).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ProfilesItems.Any(e => e.Id == profiles.Id))
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
    /// Get a gender_ record for Profiles
    /// </summary>
    public async Task<Genders> GetGender(ProfilesWhereUniqueInput uniqueId)
    {
        var profiles = await _context
            .ProfilesItems.Where(profiles => profiles.Id == uniqueId.Id)
            .Include(profiles => profiles.Gender)
            .FirstOrDefaultAsync();
        if (profiles == null)
        {
            throw new NotFoundException();
        }
        return profiles.Gender.ToDto();
    }

    /// <summary>
    /// Get a title_ record for Profiles
    /// </summary>
    public async Task<Titles> GetTitle(ProfilesWhereUniqueInput uniqueId)
    {
        var profiles = await _context
            .ProfilesItems.Where(profiles => profiles.Id == uniqueId.Id)
            .Include(profiles => profiles.Title)
            .FirstOrDefaultAsync();
        if (profiles == null)
        {
            throw new NotFoundException();
        }
        return profiles.Title.ToDto();
    }

    /// <summary>
    /// Get a user_ record for Profiles
    /// </summary>
    public async Task<User> GetUser(ProfilesWhereUniqueInput uniqueId)
    {
        var profiles = await _context
            .ProfilesItems.Where(profiles => profiles.Id == uniqueId.Id)
            .Include(profiles => profiles.User)
            .FirstOrDefaultAsync();
        if (profiles == null)
        {
            throw new NotFoundException();
        }
        return profiles.User.ToDto();
    }
}
