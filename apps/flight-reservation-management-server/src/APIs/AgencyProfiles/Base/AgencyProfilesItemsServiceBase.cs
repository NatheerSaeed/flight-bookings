using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class AgencyProfilesServiceBase : IAgencyProfilesService
{
    protected readonly FlightReservationManagementDbContext _context;

    public AgencyProfilesServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one AgencyProfiles
    /// </summary>
    public async Task<AgencyProfiles> CreateAgencyProfiles(AgencyProfileCreateInput createDto)
    {
        var agencyProfiles = new AgencyProfile
        {
            CacRcNumber = createDto.CacRcNumber,
            CompanyAddress = createDto.CompanyAddress,
            CompanyContactPersonAddress = createDto.CompanyContactPersonAddress,
            CompanyContactPersonEmail = createDto.CompanyContactPersonEmail,
            CompanyContactPersonPhoneNumber = createDto.CompanyContactPersonPhoneNumber,
            CompanyEmail = createDto.CompanyEmail,
            CompanyName = createDto.CompanyName,
            CompanyPhoneNumber = createDto.CompanyPhoneNumber,
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            agencyProfiles.Id = createDto.Id;
        }
        if (createDto.User != null)
        {
            agencyProfiles.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.AgencyProfilesItems.Add(agencyProfiles);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AgencyProfile>(agencyProfiles.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one AgencyProfiles
    /// </summary>
    public async Task DeleteAgencyProfiles(AgencyProfilesWhereUniqueInput uniqueId)
    {
        var agencyProfiles = await _context.AgencyProfilesItems.FindAsync(uniqueId.Id);
        if (agencyProfiles == null)
        {
            throw new NotFoundException();
        }

        _context.AgencyProfilesItems.Remove(agencyProfiles);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many AgencyProfilesItems
    /// </summary>
    public async Task<List<AgencyProfiles>> AgencyProfilesItems(
        AgencyProfileFindManyArgs findManyArgs
    )
    {
        var agencyProfilesItems = await _context
            .AgencyProfilesItems.Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return agencyProfilesItems.ConvertAll(agencyProfiles => agencyProfiles.ToDto());
    }

    /// <summary>
    /// Meta data about AgencyProfiles records
    /// </summary>
    public async Task<MetadataDto> AgencyProfilesItemsMeta(AgencyProfileFindManyArgs findManyArgs)
    {
        var count = await _context.AgencyProfilesItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one AgencyProfiles
    /// </summary>
    public async Task<AgencyProfiles> AgencyProfiles(AgencyProfilesWhereUniqueInput uniqueId)
    {
        var agencyProfilesItems = await this.AgencyProfilesItems(
            new AgencyProfileFindManyArgs
            {
                Where = new AgencyProfileWhereInput { Id = uniqueId.Id }
            }
        );
        var agencyProfiles = agencyProfilesItems.FirstOrDefault();
        if (agencyProfiles == null)
        {
            throw new NotFoundException();
        }

        return agencyProfiles;
    }

    /// <summary>
    /// Update one AgencyProfiles
    /// </summary>
    public async Task UpdateAgencyProfiles(
        AgencyProfilesWhereUniqueInput uniqueId,
        AgencyProfileUpdateInput updateDto
    )
    {
        var agencyProfiles = updateDto.ToModel(uniqueId);

        if (updateDto.User != null)
        {
            agencyProfiles.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(agencyProfiles).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.AgencyProfilesItems.Any(e => e.Id == agencyProfiles.Id))
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
    /// Get a user_ record for AgencyProfiles
    /// </summary>
    public async Task<User> GetUser(AgencyProfilesWhereUniqueInput uniqueId)
    {
        var agencyProfiles = await _context
            .AgencyProfilesItems.Where(agencyProfiles => agencyProfiles.Id == uniqueId.Id)
            .Include(agencyProfiles => agencyProfiles.User)
            .FirstOrDefaultAsync();
        if (agencyProfiles == null)
        {
            throw new NotFoundException();
        }
        return agencyProfiles.User.ToDto();
    }
}
