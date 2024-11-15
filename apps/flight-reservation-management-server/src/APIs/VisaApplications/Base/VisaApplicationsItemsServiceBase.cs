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
    public async Task<VisaApplications> CreateVisaApplications(VisaApplicationCreateInput createDto)
    {
        var visaApplications = new VisaApplicationsDbModel
        {
            CreatedAt = createDto.CreatedAt,
            DestinationCountry = createDto.DestinationCountry,
            Email = createDto.Email,
            GivenName = createDto.GivenName,
            IpAddress = createDto.IpAddress,
            Phone = createDto.Phone,
            ResidenceCountry = createDto.ResidenceCountry,
            Surname = createDto.Surname,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            visaApplications.Id = createDto.Id;
        }

        _context.VisaApplicationsItems.Add(visaApplications);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<VisaApplicationsDbModel>(visaApplications.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one VisaApplications
    /// </summary>
    public async Task DeleteVisaApplications(VisaApplicationsWhereUniqueInput uniqueId)
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
    public async Task<List<VisaApplications>> VisaApplicationsItems(
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
        var visaApplicationsItems = await this.VisaApplicationsItems(
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
    public async Task UpdateVisaApplications(
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
