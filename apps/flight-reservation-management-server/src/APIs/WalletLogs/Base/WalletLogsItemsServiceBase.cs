using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class WalletLogsServiceBase : IWalletLogsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public WalletLogsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one WalletLogs
    /// </summary>
    public async Task<WalletLogs> CreateWalletLogs(WalletLogCreateInput createDto)
    {
        var walletLogs = new WalletLog
        {
            Amount = createDto.Amount,
            CreatedAt = createDto.CreatedAt,
            Status = createDto.Status,
            TypeId = createDto.TypeId,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            walletLogs.Id = createDto.Id;
        }
        if (createDto.User != null)
        {
            walletLogs.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.WalletLogsItems.Add(walletLogs);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<WalletLog>(walletLogs.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one WalletLogs
    /// </summary>
    public async Task DeleteWalletLogs(WalletLogsWhereUniqueInput uniqueId)
    {
        var walletLogs = await _context.WalletLogsItems.FindAsync(uniqueId.Id);
        if (walletLogs == null)
        {
            throw new NotFoundException();
        }

        _context.WalletLogsItems.Remove(walletLogs);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many WalletLogsItems
    /// </summary>
    public async Task<List<WalletLogs>> WalletLogsItems(WalletLogFindManyArgs findManyArgs)
    {
        var walletLogsItems = await _context
            .WalletLogsItems.Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return walletLogsItems.ConvertAll(walletLogs => walletLogs.ToDto());
    }

    /// <summary>
    /// Meta data about WalletLogs records
    /// </summary>
    public async Task<MetadataDto> WalletLogsItemsMeta(WalletLogFindManyArgs findManyArgs)
    {
        var count = await _context.WalletLogsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one WalletLogs
    /// </summary>
    public async Task<WalletLogs> WalletLogs(WalletLogsWhereUniqueInput uniqueId)
    {
        var walletLogsItems = await this.WalletLogsItems(
            new WalletLogFindManyArgs { Where = new WalletLogWhereInput { Id = uniqueId.Id } }
        );
        var walletLogs = walletLogsItems.FirstOrDefault();
        if (walletLogs == null)
        {
            throw new NotFoundException();
        }

        return walletLogs;
    }

    /// <summary>
    /// Update one WalletLogs
    /// </summary>
    public async Task UpdateWalletLogs(
        WalletLogsWhereUniqueInput uniqueId,
        WalletLogUpdateInput updateDto
    )
    {
        var walletLogs = updateDto.ToModel(uniqueId);

        if (updateDto.User != null)
        {
            walletLogs.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(walletLogs).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.WalletLogsItems.Any(e => e.Id == walletLogs.Id))
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
    /// Get a user_ record for WalletLogs
    /// </summary>
    public async Task<User> GetUser(WalletLogsWhereUniqueInput uniqueId)
    {
        var walletLogs = await _context
            .WalletLogsItems.Where(walletLogs => walletLogs.Id == uniqueId.Id)
            .Include(walletLogs => walletLogs.User)
            .FirstOrDefaultAsync();
        if (walletLogs == null)
        {
            throw new NotFoundException();
        }
        return walletLogs.User.ToDto();
    }
}
