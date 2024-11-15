using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class VatsServiceBase : IVatsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public VatsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Vats
    /// </summary>
    public async Task<Vats> CreateVat(VatCreateInput inputDto)
    {
        var vats = new Vat
        {
            CarVatType = inputDto.CarVatType,
            CarVatValue = inputDto.CarVatValue,
            CreatedAt = inputDto.CreatedAt,
            FlightVatType = inputDto.FlightVatType,
            FlightVatValue = inputDto.FlightVatValue,
            HotelVatType = inputDto.HotelVatType,
            HotelVatValue = inputDto.HotelVatValue,
            PackageVatType = inputDto.PackageVatType,
            PackageVatValue = inputDto.PackageVatValue,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            vats.Id = inputDto.Id;
        }

        _context.VatsItems.Add(vats);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Vat>(vats.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Vats
    /// </summary>
    public async Task DeleteVat(VatsWhereUniqueInput uniqueId)
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
    public async Task<List<Vats>> VatsSearchAsync(VatFindManyArgs findManyArgs)
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
    public async Task<MetadataDto> VatsItemsMeta(VatFindManyArgs findManyArgs)
    {
        var count = await _context.VatsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Vats
    /// </summary>
    public async Task<Vats> Vats(VatsWhereUniqueInput uniqueId)
    {
        var vatsItems = await this.VatsSearchAsync(
            new VatFindManyArgs { Where = new VatWhereInput { Id = uniqueId.Id } }
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
    public async Task UpdateVat(VatsWhereUniqueInput uniqueId, VatUpdateInput updateDto)
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
