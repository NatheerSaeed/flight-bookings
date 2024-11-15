using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class VatsItemsServiceBase : IVatsItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public VatsItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Vats
    /// </summary>
    public async Task<Vats> CreateVats(VatsCreateInput createDto)
    {
        var vats = new VatsDbModel
        {
            CarVatType = createDto.CarVatType,
            CarVatValue = createDto.CarVatValue,
            CreatedAt = createDto.CreatedAt,
            FlightVatType = createDto.FlightVatType,
            FlightVatValue = createDto.FlightVatValue,
            HotelVatType = createDto.HotelVatType,
            HotelVatValue = createDto.HotelVatValue,
            PackageVatType = createDto.PackageVatType,
            PackageVatValue = createDto.PackageVatValue,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            vats.Id = createDto.Id;
        }

        _context.VatsItems.Add(vats);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<VatsDbModel>(vats.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Vats
    /// </summary>
    public async Task DeleteVats(VatsWhereUniqueInput uniqueId)
    {
        var vats = await _context.VatsItems.FindAsync(uniqueId.Id);
        if (vats == null)
        {
            throw new NotFoundException();
        }

        _context.VatsItems.Remove(vats);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many VatsItems
    /// </summary>
    public async Task<List<Vats>> VatsItems(VatsFindManyArgs findManyArgs)
    {
        var vatsItems = await _context
            .VatsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return vatsItems.ConvertAll(vats => vats.ToDto());
    }

    /// <summary>
    /// Meta data about Vats records
    /// </summary>
    public async Task<MetadataDto> VatsItemsMeta(VatsFindManyArgs findManyArgs)
    {
        var count = await _context.VatsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Vats
    /// </summary>
    public async Task<Vats> Vats(VatsWhereUniqueInput uniqueId)
    {
        var vatsItems = await this.VatsItems(
            new VatsFindManyArgs { Where = new VatsWhereInput { Id = uniqueId.Id } }
        );
        var vats = vatsItems.FirstOrDefault();
        if (vats == null)
        {
            throw new NotFoundException();
        }

        return vats;
    }

    /// <summary>
    /// Update one Vats
    /// </summary>
    public async Task UpdateVats(VatsWhereUniqueInput uniqueId, VatsUpdateInput updateDto)
    {
        var vats = updateDto.ToModel(uniqueId);

        _context.Entry(vats).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.VatsItems.Any(e => e.Id == vats.Id))
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
