using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IHotelDealsItemsService
{
    /// <summary>
    /// Create one HotelDeals
    /// </summary>
    public Task<HotelDeals> CreateHotelDeals(HotelDealsCreateInput hoteldeals);

    /// <summary>
    /// Delete one HotelDeals
    /// </summary>
    public Task DeleteHotelDeals(HotelDealsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many HotelDealsItems
    /// </summary>
    public Task<List<HotelDeals>> HotelDealsItems(HotelDealsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about HotelDeals records
    /// </summary>
    public Task<MetadataDto> HotelDealsItemsMeta(HotelDealsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one HotelDeals
    /// </summary>
    public Task<HotelDeals> HotelDeals(HotelDealsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one HotelDeals
    /// </summary>
    public Task UpdateHotelDeals(
        HotelDealsWhereUniqueInput uniqueId,
        HotelDealsUpdateInput updateDto
    );

    /// <summary>
    /// Get a package_ record for HotelDeals
    /// </summary>
    public Task<Packages> GetPackageField(HotelDealsWhereUniqueInput uniqueId);
}
