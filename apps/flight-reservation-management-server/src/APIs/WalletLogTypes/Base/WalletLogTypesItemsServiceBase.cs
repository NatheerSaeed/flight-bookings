using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class WalletLogTypesItemsServiceBase : IWalletLogTypesItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public WalletLogTypesItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one WalletLogTypes
    /// </summary>
    public async Task<WalletLogTypes> CreateWalletLogTypes(WalletLogTypesCreateInput createDto)
    {
        var walletLogTypes = new WalletLogTypesDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Name = createDto.Name,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            walletLogTypes.Id = createDto.Id;
        }

        _context.WalletLogTypesItems.Add(walletLogTypes);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<WalletLogTypesDbModel>(walletLogTypes.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one WalletLogTypes
    /// </summary>
    public async Task DeleteWalletLogTypes(WalletLogTypesWhereUniqueInput uniqueId)
    {
        var walletLogTypes = await _context.WalletLogTypesItems.FindAsync(uniqueId.Id);
        if (walletLogTypes == null)
        {
            throw new NotFoundException();
        }

        _context.WalletLogTypesItems.Remove(walletLogTypes);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many WalletLogTypesItems
    /// </summary>
    public async Task<List<WalletLogTypes>> WalletLogTypesItems(
        WalletLogTypesFindManyArgs findManyArgs
    )
    {
        var walletLogTypesItems = await _context
            .WalletLogTypesItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return walletLogTypesItems.ConvertAll(walletLogTypes => walletLogTypes.ToDto());
    }

    /// <summary>
    /// Meta data about WalletLogTypes records
    /// </summary>
    public async Task<MetadataDto> WalletLogTypesItemsMeta(WalletLogTypesFindManyArgs findManyArgs)
    {
        var count = await _context.WalletLogTypesItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one WalletLogTypes
    /// </summary>
    public async Task<WalletLogTypes> WalletLogTypes(WalletLogTypesWhereUniqueInput uniqueId)
    {
        var walletLogTypesItems = await this.WalletLogTypesItems(
            new WalletLogTypesFindManyArgs
            {
                Where = new WalletLogTypesWhereInput { Id = uniqueId.Id }
            }
        );
        var walletLogTypes = walletLogTypesItems.FirstOrDefault();
        if (walletLogTypes == null)
        {
            throw new NotFoundException();
        }

        return walletLogTypes;
    }

    /// <summary>
    /// Update one WalletLogTypes
    /// </summary>
    public async Task UpdateWalletLogTypes(
        WalletLogTypesWhereUniqueInput uniqueId,
        WalletLogTypesUpdateInput updateDto
    )
    {
        var walletLogTypes = updateDto.ToModel(uniqueId);

        _context.Entry(walletLogTypes).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.WalletLogTypesItems.Any(e => e.Id == walletLogTypes.Id))
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
