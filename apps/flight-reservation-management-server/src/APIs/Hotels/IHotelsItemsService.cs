using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IHotelsService
{
    /// <summary>
    /// Create one Hotels
    /// </summary>
    public Task<Hotels> CreateHotel(HotelCreateInput hotels);

    /// <summary>
    /// Delete one Hotels
    /// </summary>
    public Task DeleteHotel(HotelsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many HotelsItems
    /// </summary>
    public Task<List<Hotels>> HotelsItems(HotelFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Hotels records
    /// </summary>
    public Task<MetadataDto> HotelsItemsMeta(HotelFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Hotels
    /// </summary>
    public Task<Hotels> Hotels(HotelsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Hotels
    /// </summary>
    public Task UpdateHotel(HotelsWhereUniqueInput uniqueId, HotelUpdateInput updateDto);

    /// <summary>
    /// Get a role_ record for Hotels
    /// </summary>
    public Task<Roles> GetRole(HotelsWhereUniqueInput uniqueId);
}
