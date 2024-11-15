using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class GoodToKnowsItemsServiceBase : IGoodToKnowsItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public GoodToKnowsItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one GoodToKnows
    /// </summary>
    public async Task<GoodToKnows> CreateGoodToKnows(GoodToKnowsCreateInput createDto)
    {
        var goodToKnows = new GoodToKnowsDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            goodToKnows.Id = createDto.Id;
        }

        _context.GoodToKnowsItems.Add(goodToKnows);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<GoodToKnowsDbModel>(goodToKnows.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one GoodToKnows
    /// </summary>
    public async Task DeleteGoodToKnows(GoodToKnowsWhereUniqueInput uniqueId)
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
    public async Task<List<GoodToKnows>> GoodToKnowsItems(GoodToKnowsFindManyArgs findManyArgs)
    {
        var goodToKnowsItems = await _context
            .GoodToKnowsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return goodToKnowsItems.ConvertAll(goodToKnows => goodToKnows.ToDto());
    }

    /// <summary>
    /// Meta data about GoodToKnows records
    /// </summary>
    public async Task<MetadataDto> GoodToKnowsItemsMeta(GoodToKnowsFindManyArgs findManyArgs)
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
            new GoodToKnowsFindManyArgs { Where = new GoodToKnowsWhereInput { Id = uniqueId.Id } }
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
    public async Task UpdateGoodToKnows(
        GoodToKnowsWhereUniqueInput uniqueId,
        GoodToKnowsUpdateInput updateDto
    )
    {
        var goodToKnows = updateDto.ToModel(uniqueId);

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
}
