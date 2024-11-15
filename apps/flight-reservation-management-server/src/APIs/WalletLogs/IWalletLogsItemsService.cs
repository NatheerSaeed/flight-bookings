using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IWalletLogsService
{
    /// <summary>
    /// Create one WalletLogs
    /// </summary>
    public Task<WalletLogs> CreateWalletLogs(WalletLogCreateInput walletlogs);

    /// <summary>
    /// Delete one WalletLogs
    /// </summary>
    public Task DeleteWalletLogs(WalletLogsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many WalletLogsItems
    /// </summary>
    public Task<List<WalletLogs>> WalletLogsItems(WalletLogFindManyArgs findManyArgs);

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
    public Task UpdateWalletLogs(
        WalletLogsWhereUniqueInput uniqueId,
        WalletLogUpdateInput updateDto
    );

    /// <summary>
    /// Get a user_ record for WalletLogs
    /// </summary>
    public Task<User> GetUser(WalletLogsWhereUniqueInput uniqueId);
}
