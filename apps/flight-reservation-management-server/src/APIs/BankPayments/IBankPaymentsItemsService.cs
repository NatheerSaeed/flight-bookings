using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IBankPaymentsItemsService
{
    /// <summary>
    /// Create one BankPayments
    /// </summary>
    public Task<BankPayments> CreateBankPayments(BankPaymentsCreateInput bankpayments);

    /// <summary>
    /// Delete one BankPayments
    /// </summary>
    public Task DeleteBankPayments(BankPaymentsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many BankPaymentsItems
    /// </summary>
    public Task<List<BankPayments>> BankPaymentsItems(BankPaymentsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about BankPayments records
    /// </summary>
    public Task<MetadataDto> BankPaymentsItemsMeta(BankPaymentsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one BankPayments
    /// </summary>
    public Task<BankPayments> BankPayments(BankPaymentsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one BankPayments
    /// </summary>
    public Task UpdateBankPayments(
        BankPaymentsWhereUniqueInput uniqueId,
        BankPaymentsUpdateInput updateDto
    );

    /// <summary>
    /// Get a user_ record for BankPayments
    /// </summary>
    public Task<User> GetUser(BankPaymentsWhereUniqueInput uniqueId);
}
