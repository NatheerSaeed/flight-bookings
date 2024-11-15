using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IOnlinePaymentsService
{
    /// <summary>
    /// Create one OnlinePayments
    /// </summary>
    public Task<OnlinePayments> CreateOnlinePayment(OnlinePaymentCreateInput onlinepayments);

    /// <summary>
    /// Delete one OnlinePayments
    /// </summary>
    public Task DeleteOnlinePayment(OnlinePaymentsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many OnlinePaymentsItems
    /// </summary>
    public Task<List<OnlinePayments>> OnlinePaymentsSearchAsync(OnlinePaymentFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about OnlinePayments records
    /// </summary>
    public Task<MetadataDto> OnlinePaymentsItemsMeta(OnlinePaymentFindManyArgs findManyArgs);

    /// <summary>
    /// Get one OnlinePayments
    /// </summary>
    public Task<OnlinePayments> OnlinePayments(OnlinePaymentsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one OnlinePayments
    /// </summary>
    public Task UpdateOnlinePayment(
        OnlinePaymentsWhereUniqueInput uniqueId,
        OnlinePaymentUpdateInput updateDto
    );

    /// <summary>
    /// Get a user_ record for OnlinePayments
    /// </summary>
    public Task<User> GetUser(OnlinePaymentsWhereUniqueInput uniqueId);
}
