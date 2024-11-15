using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IAirportsService
{
    /// <summary>
    /// Create one Airports
    /// </summary>
    public Task<Airports> CreateAirport(AirportCreateInput airports);

    /// <summary>
    /// Delete one Airports
    /// </summary>
    public Task DeleteAirport(AirportsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many AirportsItems
    /// </summary>
    public Task<List<Airports>> AirportsItems(AirportFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Airports records
    /// </summary>
    public Task<MetadataDto> AirportsItemsMeta(AirportFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Airports
    /// </summary>
    public Task<Airports> Airports(AirportsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Airports
    /// </summary>
    public Task UpdateAirport(AirportsWhereUniqueInput uniqueId, AirportUpdateInput updateDto);
}
