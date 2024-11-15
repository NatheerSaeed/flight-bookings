using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IWalletLogTypesItemsService
{
    /// <summary>
    /// Create one WalletLogTypes
    /// </summary>
    public Task<WalletLogTypes> CreateWalletLogTypes(WalletLogTypesCreateInput walletlogtypes);

    /// <summary>
    /// Delete one WalletLogTypes
    /// </summary>
    public Task DeleteWalletLogTypes(WalletLogTypesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many WalletLogTypesItems
    /// </summary>
    public Task<List<WalletLogTypes>> WalletLogTypesItems(WalletLogTypesFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about WalletLogTypes records
    /// </summary>
    public Task<MetadataDto> WalletLogTypesItemsMeta(WalletLogTypesFindManyArgs findManyArgs);

    /// <summary>
    /// Get one WalletLogTypes
    /// </summary>
    public Task<WalletLogTypes> WalletLogTypes(WalletLogTypesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one WalletLogTypes
    /// </summary>
    public Task UpdateWalletLogTypes(
        WalletLogTypesWhereUniqueInput uniqueId,
        WalletLogTypesUpdateInput updateDto
    );
}
