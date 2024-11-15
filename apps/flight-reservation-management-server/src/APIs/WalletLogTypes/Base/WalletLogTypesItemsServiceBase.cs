using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class WalletLogTypesServiceBase : IWalletLogTypesService
{
    protected readonly FlightReservationManagementDbContext _context;

    public WalletLogTypesServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one WalletLogTypes
    /// </summary>
    public async Task<WalletLogTypes> CreateWalletLogType(WalletLogTypeCreateInput inputDto)
    {
        var walletLogTypes = new WalletLogType
        {
            CreatedAt = inputDto.CreatedAt,
            Name = inputDto.Name,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            walletLogTypes.Id = inputDto.Id;
        }

        _context.WalletLogTypesItems.Add(walletLogTypes);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<WalletLogType>(walletLogTypes.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one WalletLogTypes
    /// </summary>
    public async Task DeleteWalletLogType(WalletLogTypesWhereUniqueInput uniqueId)
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
    public async Task<List<WalletLogTypes>> WalletLogTypesSearchAsync(
        WalletLogTypeFindManyArgs findManyArgs
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
    public async Task<MetadataDto> WalletLogTypesItemsMeta(WalletLogTypeFindManyArgs findManyArgs)
    {
        var count = await _context.WalletLogTypesItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one WalletLogTypes
    /// </summary>
    public async Task<WalletLogTypes> WalletLogTypes(WalletLogTypesWhereUniqueInput uniqueId)
    {
        var walletLogTypesItems = await this.WalletLogTypesSearchAsync(
            new WalletLogTypeFindManyArgs
            {
                Where = new WalletLogTypeWhereInput { Id = uniqueId.Id }
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
    public async Task UpdateWalletLogType(
        WalletLogTypesWhereUniqueInput uniqueId,
        WalletLogTypeUpdateInput updateDto
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
