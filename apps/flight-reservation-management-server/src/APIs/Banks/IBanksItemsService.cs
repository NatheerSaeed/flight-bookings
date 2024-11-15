using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IBanksItemsService
{
    /// <summary>
    /// Create one Banks
    /// </summary>
    public Task<Banks> CreateBanks(BanksCreateInput banks);

    /// <summary>
    /// Delete one Banks
    /// </summary>
    public Task DeleteBanks(BanksWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many BanksItems
    /// </summary>
    public Task<List<Banks>> BanksItems(BanksFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Banks records
    /// </summary>
    public Task<MetadataDto> BanksItemsMeta(BanksFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Banks
    /// </summary>
    public Task<Banks> Banks(BanksWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Banks
    /// </summary>
    public Task UpdateBanks(BanksWhereUniqueInput uniqueId, BanksUpdateInput updateDto);

    /// <summary>
    /// Connect multiple BankDetailsItems records to Banks
    /// </summary>
    public Task ConnectBankDetailsItems(
        BanksWhereUniqueInput uniqueId,
        BankDetailsWhereUniqueInput[] bankDetailsId
    );

    /// <summary>
    /// Disconnect multiple BankDetailsItems records from Banks
    /// </summary>
    public Task DisconnectBankDetailsItems(
        BanksWhereUniqueInput uniqueId,
        BankDetailsWhereUniqueInput[] bankDetailsId
    );

    /// <summary>
    /// Find multiple BankDetailsItems records for Banks
    /// </summary>
    public Task<List<BankDetails>> FindBankDetailsItems(
        BanksWhereUniqueInput uniqueId,
        BankDetailsFindManyArgs BankDetailsFindManyArgs
    );

    /// <summary>
    /// Update multiple BankDetailsItems records for Banks
    /// </summary>
    public Task UpdateBankDetailsItems(
        BanksWhereUniqueInput uniqueId,
        BankDetailsWhereUniqueInput[] bankDetailsId
    );
}
