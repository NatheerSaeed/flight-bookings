using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface ITravelLocationsService
{
    /// <summary>
    /// Create one TravelLocation
    /// </summary>
    public Task<TravelLocation> CreateTravelLocation(TravelLocationCreateInput travellocation);

    /// <summary>
    /// Delete one TravelLocation
    /// </summary>
    public Task DeleteTravelLocation(TravelLocationWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many TravelLocations
    /// </summary>
    public Task<List<TravelLocation>> TravelLocations(TravelLocationFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about TravelLocation records
    /// </summary>
    public Task<MetadataDto> TravelLocationsMeta(TravelLocationFindManyArgs findManyArgs);

    /// <summary>
    /// Get one TravelLocation
    /// </summary>
    public Task<TravelLocation> TravelLocation(TravelLocationWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one TravelLocation
    /// </summary>
    public Task UpdateTravelLocation(
        TravelLocationWhereUniqueInput uniqueId,
        TravelLocationUpdateInput updateDto
    );
}
