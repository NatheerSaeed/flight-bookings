using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IBanksService
{
    /// <summary>
    /// Create one Banks
    /// </summary>
    public Task<Banks> CreateBanks(BankCreateInput banks);

    /// <summary>
    /// Delete one Banks
    /// </summary>
    public Task DeleteBanks(BanksWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many BanksItems
    /// </summary>
    public Task<List<Banks>> BanksItems(BankFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Banks records
    /// </summary>
    public Task<MetadataDto> BanksItemsMeta(BankFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Banks
    /// </summary>
    public Task<Banks> Banks(BanksWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Banks
    /// </summary>
    public Task UpdateBanks(BanksWhereUniqueInput uniqueId, BankUpdateInput updateDto);

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
        BankDetailFindManyArgs BankDetailFindManyArgs
    );

    /// <summary>
    /// Update multiple BankDetailsItems records for Banks
    /// </summary>
    public Task UpdateBankDetailsItems(
        BanksWhereUniqueInput uniqueId,
        BankDetailsWhereUniqueInput[] bankDetailsId
    );
}
