using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IWalletsService
{
    /// <summary>
    /// Create one Wallets
    /// </summary>
    public Task<Wallets> CreateWallets(WalletCreateInput wallets);

    /// <summary>
    /// Delete one Wallets
    /// </summary>
    public Task DeleteWallets(WalletsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many WalletsItems
    /// </summary>
    public Task<List<Wallets>> WalletsItems(WalletFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Wallets records
    /// </summary>
    public Task<MetadataDto> WalletsItemsMeta(WalletFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Wallets
    /// </summary>
    public Task<Wallets> Wallets(WalletsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Wallets
    /// </summary>
    public Task UpdateWallets(WalletsWhereUniqueInput uniqueId, WalletUpdateInput updateDto);

    /// <summary>
    /// Get a user_ record for Wallets
    /// </summary>
    public Task<User> GetUser(WalletsWhereUniqueInput uniqueId);
}
