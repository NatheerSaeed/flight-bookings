using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IAirportsItemsService
{
    /// <summary>
    /// Create one Airports
    /// </summary>
    public Task<Airports> CreateAirports(AirportsCreateInput airports);

    /// <summary>
    /// Delete one Airports
    /// </summary>
    public Task DeleteAirports(AirportsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many AirportsItems
    /// </summary>
    public Task<List<Airports>> AirportsItems(AirportsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Airports records
    /// </summary>
    public Task<MetadataDto> AirportsItemsMeta(AirportsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Airports
    /// </summary>
    public Task<Airports> Airports(AirportsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Airports
    /// </summary>
    public Task UpdateAirports(AirportsWhereUniqueInput uniqueId, AirportsUpdateInput updateDto);
}
