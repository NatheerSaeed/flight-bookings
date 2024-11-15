using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class HotelDealsServiceBase : IHotelDealsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public HotelDealsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one HotelDeals
    /// </summary>
    public async Task<HotelDeals> CreateHotelDeals(HotelDealCreateInput createDto)
    {
        var hotelDeals = new HotelDeal
        {
            Address = createDto.Address,
            City = createDto.City,
            CreatedAt = createDto.CreatedAt,
            Information = createDto.Information,
            Name = createDto.Name,
            StarRating = createDto.StarRating,
            StayDuration = createDto.StayDuration,
            StayEndDate = createDto.StayEndDate,
            StayStartDate = createDto.StayStartDate,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            hotelDeals.Id = createDto.Id;
        }
        if (createDto.PackageField != null)
        {
            hotelDeals.PackageField = await _context
                .PackagesItems.Where(packages => createDto.PackageField.Id == packages.Id)
                .FirstOrDefaultAsync();
        }

        _context.HotelDealsItems.Add(hotelDeals);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<HotelDeal>(hotelDeals.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one HotelDeals
    /// </summary>
    public async Task DeleteHotelDeals(HotelDealsWhereUniqueInput uniqueId)
    {
        var hotelDeals = await _context.HotelDealsItems.FindAsync(uniqueId.Id);
        if (hotelDeals == null)
        {
            throw new NotFoundException();
        }

        _context.HotelDealsItems.Remove(hotelDeals);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many HotelDealsItems
    /// </summary>
    public async Task<List<HotelDeals>> HotelDealsItems(HotelDealFindManyArgs findManyArgs)
    {
        var hotelDealsItems = await _context
            .HotelDealsItems.Include(x => x.PackageField)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return hotelDealsItems.ConvertAll(hotelDeals => hotelDeals.ToDto());
    }

    /// <summary>
    /// Meta data about HotelDeals records
    /// </summary>
    public async Task<MetadataDto> HotelDealsItemsMeta(HotelDealFindManyArgs findManyArgs)
    {
        var count = await _context.HotelDealsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one HotelDeals
    /// </summary>
    public async Task<HotelDeals> HotelDeals(HotelDealsWhereUniqueInput uniqueId)
    {
        var hotelDealsItems = await this.HotelDealsItems(
            new HotelDealFindManyArgs { Where = new HotelDealWhereInput { Id = uniqueId.Id } }
        );
        var hotelDeals = hotelDealsItems.FirstOrDefault();
        if (hotelDeals == null)
        {
            throw new NotFoundException();
        }

        return hotelDeals;
    }

    /// <summary>
    /// Update one HotelDeals
    /// </summary>
    public async Task UpdateHotelDeals(
        HotelDealsWhereUniqueInput uniqueId,
        HotelDealUpdateInput updateDto
    )
    {
        var hotelDeals = updateDto.ToModel(uniqueId);

        if (updateDto.PackageField != null)
        {
            hotelDeals.PackageField = await _context
                .PackagesItems.Where(packages => updateDto.PackageField == packages.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(hotelDeals).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.HotelDealsItems.Any(e => e.Id == hotelDeals.Id))
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
    /// Get a package_ record for HotelDeals
    /// </summary>
    public async Task<Packages> GetPackageField(HotelDealsWhereUniqueInput uniqueId)
    {
        var hotelDeals = await _context
            .HotelDealsItems.Where(hotelDeals => hotelDeals.Id == uniqueId.Id)
            .Include(hotelDeals => hotelDeals.PackageField)
            .FirstOrDefaultAsync();
        if (hotelDeals == null)
        {
            throw new NotFoundException();
        }
        return hotelDeals.PackageField.ToDto();
    }
}
