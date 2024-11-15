using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class VisaApplicationsServiceBase : IVisaApplicationsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public VisaApplicationsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one VisaApplications
    /// </summary>
    public async Task<VisaApplications> CreateVisaApplication(VisaApplicationCreateInput inputDto)
    {
        var visaApplications = new VisaApplication
        {
            CreatedAt = inputDto.CreatedAt,
            DestinationCountry = inputDto.DestinationCountry,
            Email = inputDto.Email,
            GivenName = inputDto.GivenName,
            IpAddress = inputDto.IpAddress,
            Phone = inputDto.Phone,
            ResidenceCountry = inputDto.ResidenceCountry,
            Surname = inputDto.Surname,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            visaApplications.Id = inputDto.Id;
        }

        _context.VisaApplicationsItems.Add(visaApplications);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<VisaApplication>(visaApplications.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one VisaApplications
    /// </summary>
    public async Task DeleteVisaApplication(VisaApplicationsWhereUniqueInput uniqueId)
    {
        var visaApplications = await _context.VisaApplicationsItems.FindAsync(uniqueId.Id);
        if (visaApplications == null)
        {
            throw new NotFoundException();
        }

        _context.VisaApplicationsItems.Remove(visaApplications);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many VisaApplicationsItems
    /// </summary>
    public async Task<List<VisaApplications>> VisaApplicationsSearchAsync(
        VisaApplicationFindManyArgs findManyArgs
    )
    {
        var visaApplicationsItems = await _context
            .VisaApplicationsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return visaApplicationsItems.ConvertAll(visaApplications => visaApplications.ToDto());
    }

    /// <summary>
    /// Meta data about VisaApplications records
    /// </summary>
    public async Task<MetadataDto> VisaApplicationsItemsMeta(
        VisaApplicationFindManyArgs findManyArgs
    )
    {
        var count = await _context
            .VisaApplicationsItems.ApplyWhere(findManyArgs.Where)
            .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one VisaApplications
    /// </summary>
    public async Task<VisaApplications> VisaApplications(VisaApplicationsWhereUniqueInput uniqueId)
    {
        var visaApplicationsItems = await this.VisaApplicationsSearchAsync(
            new VisaApplicationFindManyArgs
            {
                Where = new VisaApplicationWhereInput { Id = uniqueId.Id }
            }
        );
        var visaApplications = visaApplicationsItems.FirstOrDefault();
        if (visaApplications == null)
        {
            throw new NotFoundException();
        }

        return visaApplications;
    }

    /// <summary>
    /// Update one VisaApplications
    /// </summary>
    public async Task UpdateVisaApplication(
        VisaApplicationsWhereUniqueInput uniqueId,
        VisaApplicationUpdateInput updateDto
    )
    {
        var visaApplications = updateDto.ToModel(uniqueId);

        _context.Entry(visaApplications).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.VisaApplicationsItems.Any(e => e.Id == visaApplications.Id))
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
