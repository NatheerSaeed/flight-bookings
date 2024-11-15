using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IEmailSubscribersService
{
    /// <summary>
    /// Create one EmailSubscribers
    /// </summary>
    public Task<EmailSubscribers> CreateEmailSubscriber(
        EmailSubscriberCreateInput emailsubscribers
    );

    /// <summary>
    /// Delete one EmailSubscribers
    /// </summary>
    public Task DeleteEmailSubscriber(EmailSubscribersWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many EmailSubscribersItems
    /// </summary>
    public Task<List<EmailSubscribers>> EmailSubscribersItems(
        EmailSubscriberFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about EmailSubscribers records
    /// </summary>
    public Task<MetadataDto> EmailSubscribersItemsMeta(EmailSubscriberFindManyArgs findManyArgs);

    /// <summary>
    /// Get one EmailSubscribers
    /// </summary>
    public Task<EmailSubscribers> EmailSubscribers(EmailSubscribersWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one EmailSubscribers
    /// </summary>
    public Task UpdateEmailSubscriber(
        EmailSubscribersWhereUniqueInput uniqueId,
        EmailSubscriberUpdateInput updateDto
    );
}
