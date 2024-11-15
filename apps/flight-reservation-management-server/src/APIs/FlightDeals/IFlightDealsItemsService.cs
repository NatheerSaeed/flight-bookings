using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IFlightDealsItemsService
{
    /// <summary>
    /// Create one FlightDeals
    /// </summary>
    public Task<FlightDeals> CreateFlightDeals(FlightDealsCreateInput flightdeals);

    /// <summary>
    /// Delete one FlightDeals
    /// </summary>
    public Task DeleteFlightDeals(FlightDealsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many FlightDealsItems
    /// </summary>
    public Task<List<FlightDeals>> FlightDealsItems(FlightDealsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about FlightDeals records
    /// </summary>
    public Task<MetadataDto> FlightDealsItemsMeta(FlightDealsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one FlightDeals
    /// </summary>
    public Task<FlightDeals> FlightDeals(FlightDealsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one FlightDeals
    /// </summary>
    public Task UpdateFlightDeals(
        FlightDealsWhereUniqueInput uniqueId,
        FlightDealsUpdateInput updateDto
    );

    /// <summary>
    /// Get a package_ record for FlightDeals
    /// </summary>
    public Task<Packages> GetPackageField(FlightDealsWhereUniqueInput uniqueId);
}
