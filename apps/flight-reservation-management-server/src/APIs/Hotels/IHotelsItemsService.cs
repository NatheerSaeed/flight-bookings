using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IHotelsItemsService
{
    /// <summary>
    /// Create one Hotels
    /// </summary>
    public Task<Hotels> CreateHotels(HotelsCreateInput hotels);

    /// <summary>
    /// Delete one Hotels
    /// </summary>
    public Task DeleteHotels(HotelsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many HotelsItems
    /// </summary>
    public Task<List<Hotels>> HotelsItems(HotelsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Hotels records
    /// </summary>
    public Task<MetadataDto> HotelsItemsMeta(HotelsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Hotels
    /// </summary>
    public Task<Hotels> Hotels(HotelsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Hotels
    /// </summary>
    public Task UpdateHotels(HotelsWhereUniqueInput uniqueId, HotelsUpdateInput updateDto);

    /// <summary>
    /// Get a role_ record for Hotels
    /// </summary>
    public Task<Roles> GetRole(HotelsWhereUniqueInput uniqueId);
}
