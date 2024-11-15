using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class GoodToKnowsServiceBase : IGoodToKnowsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public GoodToKnowsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one GoodToKnows
    /// </summary>
    public async Task<GoodToKnows> CreateGoodToKnow(GoodToKnowCreateInput inputDto)
    {
        var goodToKnows = new GoodToKnow
        {
            CancellationPrepayment = inputDto.CancellationPrepayment,
            CheckIn = inputDto.CheckIn,
            CheckOut = inputDto.CheckOut,
            ChildrenBeds = inputDto.ChildrenBeds,
            CreatedAt = inputDto.CreatedAt,
            Groups = inputDto.Groups,
            Internet = inputDto.Internet,
            Pets = inputDto.Pets,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            goodToKnows.Id = inputDto.Id;
        }
        if (inputDto.PackageField != null)
        {
            goodToKnows.PackageField = await _context
                .PackagesItems.Where(packages => inputDto.PackageField.Id == packages.Id)
                .FirstOrDefaultAsync();
        }

        _context.GoodToKnowsItems.Add(goodToKnows);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<GoodToKnow>(goodToKnows.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one GoodToKnows
    /// </summary>
    public async Task DeleteGoodToKnow(GoodToKnowsWhereUniqueInput uniqueId)
    {
        var goodToKnows = await _context.GoodToKnowsItems.FindAsync(uniqueId.Id);
        if (goodToKnows == null)
        {
            throw new NotFoundException();
        }

        _context.GoodToKnowsItems.Remove(goodToKnows);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many GoodToKnowsItems
    /// </summary>
    public async Task<List<GoodToKnows>> GoodToKnowsItems(GoodToKnowFindManyArgs findManyArgs)
    {
        var goodToKnowsItems = await _context
            .GoodToKnowsItems.Include(x => x.PackageField)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return goodToKnowsItems.ConvertAll(goodToKnows => goodToKnows.ToDto());
    }

    /// <summary>
    /// Meta data about GoodToKnows records
    /// </summary>
    public async Task<MetadataDto> GoodToKnowsItemsMeta(GoodToKnowFindManyArgs findManyArgs)
    {
        var count = await _context.GoodToKnowsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one GoodToKnows
    /// </summary>
    public async Task<GoodToKnows> GoodToKnows(GoodToKnowsWhereUniqueInput uniqueId)
    {
        var goodToKnowsItems = await this.GoodToKnowsItems(
            new GoodToKnowFindManyArgs { Where = new GoodToKnowWhereInput { Id = uniqueId.Id } }
        );
        var goodToKnows = goodToKnowsItems.FirstOrDefault();
        if (goodToKnows == null)
        {
            throw new NotFoundException();
        }

        return goodToKnows;
    }

    /// <summary>
    /// Update one GoodToKnows
    /// </summary>
    public async Task UpdateGoodToKnow(
        GoodToKnowsWhereUniqueInput uniqueId,
        GoodToKnowUpdateInput updateDto
    )
    {
        var goodToKnows = updateDto.ToModel(uniqueId);

        if (updateDto.PackageField != null)
        {
            goodToKnows.PackageField = await _context
                .PackagesItems.Where(packages => updateDto.PackageField == packages.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(goodToKnows).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.GoodToKnowsItems.Any(e => e.Id == goodToKnows.Id))
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
    /// Get a package_ record for GoodToKnows
    /// </summary>
    public async Task<Packages> GetPackageField(GoodToKnowsWhereUniqueInput uniqueId)
    {
        var goodToKnows = await _context
            .GoodToKnowsItems.Where(goodToKnows => goodToKnows.Id == uniqueId.Id)
            .Include(goodToKnows => goodToKnows.PackageField)
            .FirstOrDefaultAsync();
        if (goodToKnows == null)
        {
            throw new NotFoundException();
        }
        return goodToKnows.PackageField.ToDto();
    }
}
