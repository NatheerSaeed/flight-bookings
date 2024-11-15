using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IBankPaymentsService
{
    /// <summary>
    /// Create one BankPayments
    /// </summary>
    public Task<BankPayments> CreateBankPayment(BankPaymentCreateInput bankpayments);

    /// <summary>
    /// Delete one BankPayments
    /// </summary>
    public Task DeleteBankPayment(BankPaymentsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many BankPaymentsItems
    /// </summary>
    public Task<List<BankPayments>> BankPaymentsItems(BankPaymentFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about BankPayments records
    /// </summary>
    public Task<MetadataDto> BankPaymentsItemsMeta(BankPaymentFindManyArgs findManyArgs);

    /// <summary>
    /// Get one BankPayments
    /// </summary>
    public Task<BankPayments> BankPayments(BankPaymentsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one BankPayments
    /// </summary>
    public Task UpdateBankPayment(
        BankPaymentsWhereUniqueInput uniqueId,
        BankPaymentUpdateInput updateDto
    );

    /// <summary>
    /// Get a user_ record for BankPayments
    /// </summary>
    public Task<User> GetUser(BankPaymentsWhereUniqueInput uniqueId);
}
