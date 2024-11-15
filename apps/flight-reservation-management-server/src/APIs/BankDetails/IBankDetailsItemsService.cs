using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IBankDetailsItemsService
{
    /// <summary>
    /// Create one BankDetails
    /// </summary>
    public Task<BankDetails> CreateBankDetails(BankDetailsCreateInput bankdetails);

    /// <summary>
    /// Delete one BankDetails
    /// </summary>
    public Task DeleteBankDetails(BankDetailsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many BankDetailsItems
    /// </summary>
    public Task<List<BankDetails>> BankDetailsItems(BankDetailsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about BankDetails records
    /// </summary>
    public Task<MetadataDto> BankDetailsItemsMeta(BankDetailsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one BankDetails
    /// </summary>
    public Task<BankDetails> BankDetails(BankDetailsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one BankDetails
    /// </summary>
    public Task UpdateBankDetails(
        BankDetailsWhereUniqueInput uniqueId,
        BankDetailsUpdateInput updateDto
    );

    /// <summary>
    /// Get a bank_ record for BankDetails
    /// </summary>
    public Task<Banks> GetBank(BankDetailsWhereUniqueInput uniqueId);
}
