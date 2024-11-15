using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IWalletsItemsService
{
    /// <summary>
    /// Create one Wallets
    /// </summary>
    public Task<Wallets> CreateWallets(WalletsCreateInput wallets);

    /// <summary>
    /// Delete one Wallets
    /// </summary>
    public Task DeleteWallets(WalletsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many WalletsItems
    /// </summary>
    public Task<List<Wallets>> WalletsItems(WalletsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Wallets records
    /// </summary>
    public Task<MetadataDto> WalletsItemsMeta(WalletsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Wallets
    /// </summary>
    public Task<Wallets> Wallets(WalletsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Wallets
    /// </summary>
    public Task UpdateWallets(WalletsWhereUniqueInput uniqueId, WalletsUpdateInput updateDto);

    /// <summary>
    /// Get a user_ record for Wallets
    /// </summary>
    public Task<User> GetUser(WalletsWhereUniqueInput uniqueId);
}
