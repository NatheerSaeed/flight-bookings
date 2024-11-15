using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class HotelsItemsServiceBase : IHotelsItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public HotelsItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Hotels
    /// </summary>
    public async Task<Hotels> CreateHotels(HotelsCreateInput createDto)
    {
        var hotels = new HotelsDbModel
        {
            CarMarkupType = createDto.CarMarkupType,
            CarMarkupValue = createDto.CarMarkupValue,
            Code = createDto.Code,
            CreatedAt = createDto.CreatedAt,
            FlightMarkupType = createDto.FlightMarkupType,
            FlightMarkupValue = createDto.FlightMarkupValue,
            HotelMarkupType = createDto.HotelMarkupType,
            HotelMarkupValue = createDto.HotelMarkupValue,
            IcaoCode = createDto.IcaoCode,
            Name = createDto.Name,
            PackageMarkupType = createDto.PackageMarkupType,
            PackageMarkupValue = createDto.PackageMarkupValue,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            hotels.Id = createDto.Id;
        }
        if (createDto.Role != null)
        {
            hotels.Role = await _context
                .RolesItems.Where(roles => createDto.Role.Id == roles.Id)
                .FirstOrDefaultAsync();
        }

        _context.HotelsItems.Add(hotels);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<HotelsDbModel>(hotels.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Hotels
    /// </summary>
    public async Task DeleteHotels(HotelsWhereUniqueInput uniqueId)
    {
        var hotels = await _context.HotelsItems.FindAsync(uniqueId.Id);
        if (hotels == null)
        {
            throw new NotFoundException();
        }

        _context.HotelsItems.Remove(hotels);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many HotelsItems
    /// </summary>
    public async Task<List<Hotels>> HotelsItems(HotelsFindManyArgs findManyArgs)
    {
        var hotelsItems = await _context
            .HotelsItems.Include(x => x.Role)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return hotelsItems.ConvertAll(hotels => hotels.ToDto());
    }

    /// <summary>
    /// Meta data about Hotels records
    /// </summary>
    public async Task<MetadataDto> HotelsItemsMeta(HotelsFindManyArgs findManyArgs)
    {
        var count = await _context.HotelsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Hotels
    /// </summary>
    public async Task<Hotels> Hotels(HotelsWhereUniqueInput uniqueId)
    {
        var hotelsItems = await this.HotelsItems(
            new HotelsFindManyArgs { Where = new HotelsWhereInput { Id = uniqueId.Id } }
        );
        var hotels = hotelsItems.FirstOrDefault();
        if (hotels == null)
        {
            throw new NotFoundException();
        }

        return hotels;
    }

    /// <summary>
    /// Update one Hotels
    /// </summary>
    public async Task UpdateHotels(HotelsWhereUniqueInput uniqueId, HotelsUpdateInput updateDto)
    {
        var hotels = updateDto.ToModel(uniqueId);

        if (updateDto.Role != null)
        {
            hotels.Role = await _context
                .RolesItems.Where(roles => updateDto.Role == roles.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(hotels).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.HotelsItems.Any(e => e.Id == hotels.Id))
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
    /// Get a role_ record for Hotels
    /// </summary>
    public async Task<Roles> GetRole(HotelsWhereUniqueInput uniqueId)
    {
        var hotels = await _context
            .HotelsItems.Where(hotels => hotels.Id == uniqueId.Id)
            .Include(hotels => hotels.Role)
            .FirstOrDefaultAsync();
        if (hotels == null)
        {
            throw new NotFoundException();
        }
        return hotels.Role.ToDto();
    }
}
