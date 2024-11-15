using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IAirlinesItemsService
{
    /// <summary>
    /// Create one Airlines
    /// </summary>
    public Task<Airlines> CreateAirlines(AirlinesCreateInput airlines);

    /// <summary>
    /// Delete one Airlines
    /// </summary>
    public Task DeleteAirlines(AirlinesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many AirlinesItems
    /// </summary>
    public Task<List<Airlines>> AirlinesItems(AirlinesFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Airlines records
    /// </summary>
    public Task<MetadataDto> AirlinesItemsMeta(AirlinesFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Airlines
    /// </summary>
    public Task<Airlines> Airlines(AirlinesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Airlines
    /// </summary>
    public Task UpdateAirlines(AirlinesWhereUniqueInput uniqueId, AirlinesUpdateInput updateDto);

    /// <summary>
    /// Get a user_ record for Airlines
    /// </summary>
    public Task<User> GetUser(AirlinesWhereUniqueInput uniqueId);
}
