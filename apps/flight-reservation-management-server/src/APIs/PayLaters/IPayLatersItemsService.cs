using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPayLatersItemsService
{
    /// <summary>
    /// Create one PayLaters
    /// </summary>
    public Task<PayLaters> CreatePayLaters(PayLatersCreateInput paylaters);

    /// <summary>
    /// Delete one PayLaters
    /// </summary>
    public Task DeletePayLaters(PayLatersWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PayLatersItems
    /// </summary>
    public Task<List<PayLaters>> PayLatersItems(PayLatersFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about PayLaters records
    /// </summary>
    public Task<MetadataDto> PayLatersItemsMeta(PayLatersFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PayLaters
    /// </summary>
    public Task<PayLaters> PayLaters(PayLatersWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PayLaters
    /// </summary>
    public Task UpdatePayLaters(PayLatersWhereUniqueInput uniqueId, PayLatersUpdateInput updateDto);

    /// <summary>
    /// Get a user_ record for PayLaters
    /// </summary>
    public Task<User> GetUser(PayLatersWhereUniqueInput uniqueId);
}
