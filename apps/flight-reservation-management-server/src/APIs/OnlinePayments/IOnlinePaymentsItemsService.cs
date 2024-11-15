using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IOnlinePaymentsItemsService
{
    /// <summary>
    /// Create one OnlinePayments
    /// </summary>
    public Task<OnlinePayments> CreateOnlinePayments(OnlinePaymentsCreateInput onlinepayments);

    /// <summary>
    /// Delete one OnlinePayments
    /// </summary>
    public Task DeleteOnlinePayments(OnlinePaymentsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many OnlinePaymentsItems
    /// </summary>
    public Task<List<OnlinePayments>> OnlinePaymentsItems(OnlinePaymentsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about OnlinePayments records
    /// </summary>
    public Task<MetadataDto> OnlinePaymentsItemsMeta(OnlinePaymentsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one OnlinePayments
    /// </summary>
    public Task<OnlinePayments> OnlinePayments(OnlinePaymentsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one OnlinePayments
    /// </summary>
    public Task UpdateOnlinePayments(
        OnlinePaymentsWhereUniqueInput uniqueId,
        OnlinePaymentsUpdateInput updateDto
    );
}
