using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IWalletLogTypesService
{
    /// <summary>
    /// Create one WalletLogTypes
    /// </summary>
    public Task<WalletLogTypes> CreateWalletLogType(WalletLogTypeCreateInput walletlogtypes);

    /// <summary>
    /// Delete one WalletLogTypes
    /// </summary>
    public Task DeleteWalletLogType(WalletLogTypesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many WalletLogTypesItems
    /// </summary>
    public Task<List<WalletLogTypes>> WalletLogTypesItems(WalletLogTypeFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about WalletLogTypes records
    /// </summary>
    public Task<MetadataDto> WalletLogTypesItemsMeta(WalletLogTypeFindManyArgs findManyArgs);

    /// <summary>
    /// Get one WalletLogTypes
    /// </summary>
    public Task<WalletLogTypes> WalletLogTypes(WalletLogTypesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one WalletLogTypes
    /// </summary>
    public Task UpdateWalletLogType(
        WalletLogTypesWhereUniqueInput uniqueId,
        WalletLogTypeUpdateInput updateDto
    );
}
