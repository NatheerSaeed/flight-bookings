using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IAirlinesService
{
    /// <summary>
    /// Create one Airlines
    /// </summary>
    public Task<Airlines> CreateAirline(AirlineCreateInput airlines);

    /// <summary>
    /// Delete one Airlines
    /// </summary>
    public Task DeleteAirline(AirlinesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many AirlinesItems
    /// </summary>
    public Task<List<Airlines>> AirlinesSearchAsync(AirlineFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Airlines records
    /// </summary>
    public Task<MetadataDto> AirlinesItemsMeta(AirlineFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Airlines
    /// </summary>
    public Task<Airlines> Airlines(AirlinesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Airlines
    /// </summary>
    public Task UpdateAirline(AirlinesWhereUniqueInput uniqueId, AirlineUpdateInput updateDto);

    /// <summary>
    /// Get a user_ record for Airlines
    /// </summary>
    public Task<User> GetUser(AirlinesWhereUniqueInput uniqueId);
}
