using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IFlightDealsService
{
    /// <summary>
    /// Create one FlightDeals
    /// </summary>
    public Task<FlightDeals> CreateFlightDeal(FlightDealCreateInput flightdeals);

    /// <summary>
    /// Delete one FlightDeals
    /// </summary>
    public Task DeleteFlightDeal(FlightDealsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many FlightDealsItems
    /// </summary>
    public Task<List<FlightDeals>> FlightDealsSearchAsync(FlightDealFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about FlightDeals records
    /// </summary>
    public Task<MetadataDto> FlightDealsItemsMeta(FlightDealFindManyArgs findManyArgs);

    /// <summary>
    /// Get one FlightDeals
    /// </summary>
    public Task<FlightDeals> FlightDeals(FlightDealsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one FlightDeals
    /// </summary>
    public Task UpdateFlightDeal(
        FlightDealsWhereUniqueInput uniqueId,
        FlightDealUpdateInput updateDto
    );

    /// <summary>
    /// Get a package_ record for FlightDeals
    /// </summary>
    public Task<Packages> GetPackageField(FlightDealsWhereUniqueInput uniqueId);
}
