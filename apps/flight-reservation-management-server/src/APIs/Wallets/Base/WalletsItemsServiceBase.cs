using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class WalletsItemsServiceBase : IWalletsItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public WalletsItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Wallets
    /// </summary>
    public async Task<Wallets> CreateWallets(WalletsCreateInput createDto)
    {
        var wallets = new WalletsDbModel
        {
            Balance = createDto.Balance,
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            wallets.Id = createDto.Id;
        }
        if (createDto.User != null)
        {
            wallets.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.WalletsItems.Add(wallets);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<WalletsDbModel>(wallets.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Wallets
    /// </summary>
    public async Task DeleteWallets(WalletsWhereUniqueInput uniqueId)
    {
        var wallets = await _context.WalletsItems.FindAsync(uniqueId.Id);
        if (wallets == null)
        {
            throw new NotFoundException();
        }

        _context.WalletsItems.Remove(wallets);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many WalletsItems
    /// </summary>
    public async Task<List<Wallets>> WalletsItems(WalletsFindManyArgs findManyArgs)
    {
        var walletsItems = await _context
            .WalletsItems.Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return walletsItems.ConvertAll(wallets => wallets.ToDto());
    }

    /// <summary>
    /// Meta data about Wallets records
    /// </summary>
    public async Task<MetadataDto> WalletsItemsMeta(WalletsFindManyArgs findManyArgs)
    {
        var count = await _context.WalletsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Wallets
    /// </summary>
    public async Task<Wallets> Wallets(WalletsWhereUniqueInput uniqueId)
    {
        var walletsItems = await this.WalletsItems(
            new WalletsFindManyArgs { Where = new WalletsWhereInput { Id = uniqueId.Id } }
        );
        var wallets = walletsItems.FirstOrDefault();
        if (wallets == null)
        {
            throw new NotFoundException();
        }

        return wallets;
    }

    /// <summary>
    /// Update one Wallets
    /// </summary>
    public async Task UpdateWallets(WalletsWhereUniqueInput uniqueId, WalletsUpdateInput updateDto)
    {
        var wallets = updateDto.ToModel(uniqueId);

        if (updateDto.User != null)
        {
            wallets.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(wallets).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.WalletsItems.Any(e => e.Id == wallets.Id))
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
    /// Get a user_ record for Wallets
    /// </summary>
    public async Task<User> GetUser(WalletsWhereUniqueInput uniqueId)
    {
        var wallets = await _context
            .WalletsItems.Where(wallets => wallets.Id == uniqueId.Id)
            .Include(wallets => wallets.User)
            .FirstOrDefaultAsync();
        if (wallets == null)
        {
            throw new NotFoundException();
        }
        return wallets.User.ToDto();
    }
}
