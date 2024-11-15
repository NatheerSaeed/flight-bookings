using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class ProfilesServiceBase : IProfilesService
{
    protected readonly FlightReservationManagementDbContext _context;

    public ProfilesServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Profiles
    /// </summary>
    public async Task<Profiles> CreateProfiles(ProfileCreateInput inputDto)
    {
        var profiles = new Profile
        {
            Address = inputDto.Address,
            CreatedAt = inputDto.CreatedAt,
            FirstName = inputDto.FirstName,
            OtherName = inputDto.OtherName,
            PhoneNumber = inputDto.PhoneNumber,
            Photo = inputDto.Photo,
            SurName = inputDto.SurName,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            profiles.Id = inputDto.Id;
        }
        if (inputDto.Gender != null)
        {
            profiles.Gender = await _context
                .GendersItems.Where(genders => inputDto.Gender.Id == genders.Id)
                .FirstOrDefaultAsync();
        }

        if (inputDto.Title != null)
        {
            profiles.Title = await _context
                .TitlesItems.Where(titles => inputDto.Title.Id == titles.Id)
                .FirstOrDefaultAsync();
        }

        if (inputDto.User != null)
        {
            profiles.User = await _context
                .Users.Where(user => inputDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.ProfilesItems.Add(profiles);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Profile>(profiles.Id);

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
    public async Task<List<Profiles>> ProfilesItems(ProfileFindManyArgs findManyArgs)
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
    public async Task<MetadataDto> ProfilesItemsMeta(ProfileFindManyArgs findManyArgs)
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
            new ProfileFindManyArgs { Where = new ProfileWhereInput { Id = uniqueId.Id } }
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
        ProfileUpdateInput updateDto
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
