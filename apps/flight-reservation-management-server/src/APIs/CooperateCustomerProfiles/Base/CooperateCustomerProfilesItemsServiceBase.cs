using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class CooperateCustomerProfilesServiceBase : ICooperateCustomerProfilesService
{
    protected readonly FlightReservationManagementDbContext _context;

    public CooperateCustomerProfilesServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one CooperateCustomerProfiles
    /// </summary>
    public async Task<CooperateCustomerProfiles> CreateCooperateCustomerProfile(
        CooperateCustomerProfileCreateInput inputDto
    )
    {
        var cooperateCustomerProfiles = new CooperateCustomerProfile
        {
            CompanyAddress = inputDto.CompanyAddress,
            CompanyCacRcNumber = inputDto.CompanyCacRcNumber,
            CompanyContactPersonAddress = inputDto.CompanyContactPersonAddress,
            CompanyContactPersonEmail = inputDto.CompanyContactPersonEmail,
            CompanyContactPersonPhoneNumber = inputDto.CompanyContactPersonPhoneNumber,
            CompanyEmail = inputDto.CompanyEmail,
            CompanyName = inputDto.CompanyName,
            CompanyPhoneNumber = inputDto.CompanyPhoneNumber,
            CreatedAt = inputDto.CreatedAt,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            cooperateCustomerProfiles.Id = inputDto.Id;
        }
        if (inputDto.User != null)
        {
            cooperateCustomerProfiles.User = await _context
                .Users.Where(user => inputDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.CooperateCustomerProfilesItems.Add(cooperateCustomerProfiles);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CooperateCustomerProfile>(
            cooperateCustomerProfiles.Id
        );

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one CooperateCustomerProfiles
    /// </summary>
    public async Task DeleteCooperateCustomerProfile(
        CooperateCustomerProfilesWhereUniqueInput uniqueId
    )
    {
        var cooperateCustomerProfiles = await _context.CooperateCustomerProfilesItems.FindAsync(
            uniqueId.Id
        );
        if (cooperateCustomerProfiles == null)
        {
            throw new NotFoundException();
        }

        _context.CooperateCustomerProfilesItems.Remove(cooperateCustomerProfiles);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many CooperateCustomerProfilesItems
    /// </summary>
    public async Task<List<CooperateCustomerProfiles>> CooperateCustomerProfilesItems(
        CooperateCustomerProfileFindManyArgs findManyArgs
    )
    {
        var cooperateCustomerProfilesItems = await _context
            .CooperateCustomerProfilesItems.Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return cooperateCustomerProfilesItems.ConvertAll(cooperateCustomerProfiles =>
            cooperateCustomerProfiles.ToDto()
        );
    }

    /// <summary>
    /// Meta data about CooperateCustomerProfiles records
    /// </summary>
    public async Task<MetadataDto> CooperateCustomerProfilesItemsMeta(
        CooperateCustomerProfileFindManyArgs findManyArgs
    )
    {
        var count = await _context
            .CooperateCustomerProfilesItems.ApplyWhere(findManyArgs.Where)
            .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one CooperateCustomerProfiles
    /// </summary>
    public async Task<CooperateCustomerProfiles> CooperateCustomerProfiles(
        CooperateCustomerProfilesWhereUniqueInput uniqueId
    )
    {
        var cooperateCustomerProfilesItems = await this.CooperateCustomerProfilesItems(
            new CooperateCustomerProfileFindManyArgs
            {
                Where = new CooperateCustomerProfileWhereInput { Id = uniqueId.Id }
            }
        );
        var cooperateCustomerProfiles = cooperateCustomerProfilesItems.FirstOrDefault();
        if (cooperateCustomerProfiles == null)
        {
            throw new NotFoundException();
        }

        return cooperateCustomerProfiles;
    }

    /// <summary>
    /// Update one CooperateCustomerProfiles
    /// </summary>
    public async Task UpdateCooperateCustomerProfile(
        CooperateCustomerProfilesWhereUniqueInput uniqueId,
        CooperateCustomerProfileUpdateInput updateDto
    )
    {
        var cooperateCustomerProfiles = updateDto.ToModel(uniqueId);

        if (updateDto.User != null)
        {
            cooperateCustomerProfiles.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(cooperateCustomerProfiles).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (
                !_context.CooperateCustomerProfilesItems.Any(e =>
                    e.Id == cooperateCustomerProfiles.Id
                )
            )
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
    /// Get a user_ record for CooperateCustomerProfiles
    /// </summary>
    public async Task<User> GetUser(CooperateCustomerProfilesWhereUniqueInput uniqueId)
    {
        var cooperateCustomerProfiles = await _context
            .CooperateCustomerProfilesItems.Where(cooperateCustomerProfiles =>
                cooperateCustomerProfiles.Id == uniqueId.Id
            )
            .Include(cooperateCustomerProfiles => cooperateCustomerProfiles.User)
            .FirstOrDefaultAsync();
        if (cooperateCustomerProfiles == null)
        {
            throw new NotFoundException();
        }
        return cooperateCustomerProfiles.User.ToDto();
    }
}
