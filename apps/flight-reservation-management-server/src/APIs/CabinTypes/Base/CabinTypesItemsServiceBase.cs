using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class CabinTypesItemsServiceBase : ICabinTypesItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public CabinTypesItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one CabinTypes
    /// </summary>
    public async Task<CabinTypes> CreateCabinTypes(CabinTypesCreateInput createDto)
    {
        var cabinTypes = new CabinTypesDbModel
        {
            CabinCode = createDto.CabinCode,
            CabinName = createDto.CabinName,
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            cabinTypes.Id = createDto.Id;
        }

        _context.CabinTypesItems.Add(cabinTypes);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CabinTypesDbModel>(cabinTypes.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one CabinTypes
    /// </summary>
    public async Task DeleteCabinTypes(CabinTypesWhereUniqueInput uniqueId)
    {
        var cabinTypes = await _context.CabinTypesItems.FindAsync(uniqueId.Id);
        if (cabinTypes == null)
        {
            throw new NotFoundException();
        }

        _context.CabinTypesItems.Remove(cabinTypes);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many CabinTypesItems
    /// </summary>
    public async Task<List<CabinTypes>> CabinTypesItems(CabinTypesFindManyArgs findManyArgs)
    {
        var cabinTypesItems = await _context
            .CabinTypesItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return cabinTypesItems.ConvertAll(cabinTypes => cabinTypes.ToDto());
    }

    /// <summary>
    /// Meta data about CabinTypes records
    /// </summary>
    public async Task<MetadataDto> CabinTypesItemsMeta(CabinTypesFindManyArgs findManyArgs)
    {
        var count = await _context.CabinTypesItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one CabinTypes
    /// </summary>
    public async Task<CabinTypes> CabinTypes(CabinTypesWhereUniqueInput uniqueId)
    {
        var cabinTypesItems = await this.CabinTypesItems(
            new CabinTypesFindManyArgs { Where = new CabinTypesWhereInput { Id = uniqueId.Id } }
        );
        var cabinTypes = cabinTypesItems.FirstOrDefault();
        if (cabinTypes == null)
        {
            throw new NotFoundException();
        }

        return cabinTypes;
    }

    /// <summary>
    /// Update one CabinTypes
    /// </summary>
    public async Task UpdateCabinTypes(
        CabinTypesWhereUniqueInput uniqueId,
        CabinTypesUpdateInput updateDto
    )
    {
        var cabinTypes = updateDto.ToModel(uniqueId);

        _context.Entry(cabinTypes).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.CabinTypesItems.Any(e => e.Id == cabinTypes.Id))
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
