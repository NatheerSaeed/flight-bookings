using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IWalletLogsService
{
    /// <summary>
    /// Create one WalletLogs
    /// </summary>
    public Task<WalletLogs> CreateWalletLog(WalletLogCreateInput walletlogs);

    /// <summary>
    /// Delete one WalletLogs
    /// </summary>
    public Task DeleteWalletLog(WalletLogsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many WalletLogsItems
    /// </summary>
    public Task<List<WalletLogs>> WalletLogsSearchAsync(WalletLogFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about WalletLogs records
    /// </summary>
    public Task<MetadataDto> WalletLogsItemsMeta(WalletLogFindManyArgs findManyArgs);

    /// <summary>
    /// Get one WalletLogs
    /// </summary>
    public Task<WalletLogs> WalletLogs(WalletLogsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one WalletLogs
    /// </summary>
    public Task UpdateWalletLog(
        WalletLogsWhereUniqueInput uniqueId,
        WalletLogUpdateInput updateDto
    );

    /// <summary>
    /// Get a user_ record for WalletLogs
    /// </summary>
    public Task<User> GetUser(WalletLogsWhereUniqueInput uniqueId);
}
