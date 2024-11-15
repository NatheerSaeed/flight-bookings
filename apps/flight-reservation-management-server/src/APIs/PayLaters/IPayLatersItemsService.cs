using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPayLatersService
{
    /// <summary>
    /// Create one PayLaters
    /// </summary>
    public Task<PayLaters> CreatePayLater(PayLaterCreateInput paylaters);

    /// <summary>
    /// Delete one PayLaters
    /// </summary>
    public Task DeletePayLater(PayLatersWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PayLatersItems
    /// </summary>
    public Task<List<PayLaters>> PayLatersItems(PayLaterFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about PayLaters records
    /// </summary>
    public Task<MetadataDto> PayLatersItemsMeta(PayLaterFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PayLaters
    /// </summary>
    public Task<PayLaters> PayLaters(PayLatersWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PayLaters
    /// </summary>
    public Task UpdatePayLater(PayLatersWhereUniqueInput uniqueId, PayLaterUpdateInput updateDto);

    /// <summary>
    /// Get a user_ record for PayLaters
    /// </summary>
    public Task<User> GetUser(PayLatersWhereUniqueInput uniqueId);
}
