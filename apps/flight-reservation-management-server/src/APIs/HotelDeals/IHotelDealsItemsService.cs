using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IHotelDealsService
{
    /// <summary>
    /// Create one HotelDeals
    /// </summary>
    public Task<HotelDeals> CreateHotelDeals(HotelDealCreateInput hoteldeals);

    /// <summary>
    /// Delete one HotelDeals
    /// </summary>
    public Task DeleteHotelDeals(HotelDealsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many HotelDealsItems
    /// </summary>
    public Task<List<HotelDeals>> HotelDealsItems(HotelDealFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about HotelDeals records
    /// </summary>
    public Task<MetadataDto> HotelDealsItemsMeta(HotelDealFindManyArgs findManyArgs);

    /// <summary>
    /// Get one HotelDeals
    /// </summary>
    public Task<HotelDeals> HotelDeals(HotelDealsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one HotelDeals
    /// </summary>
    public Task UpdateHotelDeals(
        HotelDealsWhereUniqueInput uniqueId,
        HotelDealUpdateInput updateDto
    );

    /// <summary>
    /// Get a package_ record for HotelDeals
    /// </summary>
    public Task<Packages> GetPackageField(HotelDealsWhereUniqueInput uniqueId);
}
