using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IBankDetailsService
{
    /// <summary>
    /// Create one BankDetails
    /// </summary>
    public Task<BankDetails> CreateBankDetail(BankDetailCreateInput bankdetails);

    /// <summary>
    /// Delete one BankDetails
    /// </summary>
    public Task DeleteBankDetail(BankDetailsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many BankDetailsItems
    /// </summary>
    public Task<List<BankDetails>> BankDetailsSearchAsync(BankDetailFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about BankDetails records
    /// </summary>
    public Task<MetadataDto> BankDetailsItemsMeta(BankDetailFindManyArgs findManyArgs);

    /// <summary>
    /// Get one BankDetails
    /// </summary>
    public Task<BankDetails> BankDetails(BankDetailsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one BankDetails
    /// </summary>
    public Task UpdateBankDetail(
        BankDetailsWhereUniqueInput uniqueId,
        BankDetailUpdateInput updateDto
    );

    /// <summary>
    /// Get a bank_ record for BankDetails
    /// </summary>
    public Task<Banks> GetBank(BankDetailsWhereUniqueInput uniqueId);
}
