using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IEmailSubscribersItemsService
{
    /// <summary>
    /// Create one EmailSubscribers
    /// </summary>
    public Task<EmailSubscribers> CreateEmailSubscribers(
        EmailSubscribersCreateInput emailsubscribers
    );

    /// <summary>
    /// Delete one EmailSubscribers
    /// </summary>
    public Task DeleteEmailSubscribers(EmailSubscribersWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many EmailSubscribersItems
    /// </summary>
    public Task<List<EmailSubscribers>> EmailSubscribersItems(
        EmailSubscribersFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about EmailSubscribers records
    /// </summary>
    public Task<MetadataDto> EmailSubscribersItemsMeta(EmailSubscribersFindManyArgs findManyArgs);

    /// <summary>
    /// Get one EmailSubscribers
    /// </summary>
    public Task<EmailSubscribers> EmailSubscribers(EmailSubscribersWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one EmailSubscribers
    /// </summary>
    public Task UpdateEmailSubscribers(
        EmailSubscribersWhereUniqueInput uniqueId,
        EmailSubscribersUpdateInput updateDto
    );
}
