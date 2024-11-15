using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPackagesItemsService
{
    /// <summary>
    /// Create one Packages
    /// </summary>
    public Task<Packages> CreatePackages(PackagesCreateInput packages);

    /// <summary>
    /// Delete one Packages
    /// </summary>
    public Task DeletePackages(PackagesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PackagesItems
    /// </summary>
    public Task<List<Packages>> PackagesItems(PackagesFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Packages records
    /// </summary>
    public Task<MetadataDto> PackagesItemsMeta(PackagesFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Packages
    /// </summary>
    public Task<Packages> Packages(PackagesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Packages
    /// </summary>
    public Task UpdatePackages(PackagesWhereUniqueInput uniqueId, PackagesUpdateInput updateDto);

    /// <summary>
    /// Connect multiple AttractionsItems records to Packages
    /// </summary>
    public Task ConnectAttractionsItems(
        PackagesWhereUniqueInput uniqueId,
        AttractionsWhereUniqueInput[] attractionsId
    );

    /// <summary>
    /// Disconnect multiple AttractionsItems records from Packages
    /// </summary>
    public Task DisconnectAttractionsItems(
        PackagesWhereUniqueInput uniqueId,
        AttractionsWhereUniqueInput[] attractionsId
    );

    /// <summary>
    /// Find multiple AttractionsItems records for Packages
    /// </summary>
    public Task<List<Attractions>> FindAttractionsItems(
        PackagesWhereUniqueInput uniqueId,
        AttractionsFindManyArgs AttractionsFindManyArgs
    );

    /// <summary>
    /// Update multiple AttractionsItems records for Packages
    /// </summary>
    public Task UpdateAttractionsItems(
        PackagesWhereUniqueInput uniqueId,
        AttractionsWhereUniqueInput[] attractionsId
    );

    /// <summary>
    /// Connect multiple FlightDealsItems records to Packages
    /// </summary>
    public Task ConnectFlightDealsItems(
        PackagesWhereUniqueInput uniqueId,
        FlightDealsWhereUniqueInput[] flightDealsId
    );

    /// <summary>
    /// Disconnect multiple FlightDealsItems records from Packages
    /// </summary>
    public Task DisconnectFlightDealsItems(
        PackagesWhereUniqueInput uniqueId,
        FlightDealsWhereUniqueInput[] flightDealsId
    );

    /// <summary>
    /// Find multiple FlightDealsItems records for Packages
    /// </summary>
    public Task<List<FlightDeals>> FindFlightDealsItems(
        PackagesWhereUniqueInput uniqueId,
        FlightDealsFindManyArgs FlightDealsFindManyArgs
    );

    /// <summary>
    /// Update multiple FlightDealsItems records for Packages
    /// </summary>
    public Task UpdateFlightDealsItems(
        PackagesWhereUniqueInput uniqueId,
        FlightDealsWhereUniqueInput[] flightDealsId
    );

    /// <summary>
    /// Connect multiple HotelDealsItems records to Packages
    /// </summary>
    public Task ConnectHotelDealsItems(
        PackagesWhereUniqueInput uniqueId,
        HotelDealsWhereUniqueInput[] hotelDealsId
    );

    /// <summary>
    /// Disconnect multiple HotelDealsItems records from Packages
    /// </summary>
    public Task DisconnectHotelDealsItems(
        PackagesWhereUniqueInput uniqueId,
        HotelDealsWhereUniqueInput[] hotelDealsId
    );

    /// <summary>
    /// Find multiple HotelDealsItems records for Packages
    /// </summary>
    public Task<List<HotelDeals>> FindHotelDealsItems(
        PackagesWhereUniqueInput uniqueId,
        HotelDealsFindManyArgs HotelDealsFindManyArgs
    );

    /// <summary>
    /// Update multiple HotelDealsItems records for Packages
    /// </summary>
    public Task UpdateHotelDealsItems(
        PackagesWhereUniqueInput uniqueId,
        HotelDealsWhereUniqueInput[] hotelDealsId
    );

    /// <summary>
    /// Connect multiple PackageFlightsItems records to Packages
    /// </summary>
    public Task ConnectPackageFlightsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageFlightsWhereUniqueInput[] packageFlightsId
    );

    /// <summary>
    /// Disconnect multiple PackageFlightsItems records from Packages
    /// </summary>
    public Task DisconnectPackageFlightsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageFlightsWhereUniqueInput[] packageFlightsId
    );

    /// <summary>
    /// Find multiple PackageFlightsItems records for Packages
    /// </summary>
    public Task<List<PackageFlights>> FindPackageFlightsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageFlightsFindManyArgs PackageFlightsFindManyArgs
    );

    /// <summary>
    /// Update multiple PackageFlightsItems records for Packages
    /// </summary>
    public Task UpdatePackageFlightsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageFlightsWhereUniqueInput[] packageFlightsId
    );

    /// <summary>
    /// Connect multiple PackageHotelsItems records to Packages
    /// </summary>
    public Task ConnectPackageHotelsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageHotelsWhereUniqueInput[] packageHotelsId
    );

    /// <summary>
    /// Disconnect multiple PackageHotelsItems records from Packages
    /// </summary>
    public Task DisconnectPackageHotelsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageHotelsWhereUniqueInput[] packageHotelsId
    );

    /// <summary>
    /// Find multiple PackageHotelsItems records for Packages
    /// </summary>
    public Task<List<PackageHotels>> FindPackageHotelsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageHotelsFindManyArgs PackageHotelsFindManyArgs
    );

    /// <summary>
    /// Update multiple PackageHotelsItems records for Packages
    /// </summary>
    public Task UpdatePackageHotelsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageHotelsWhereUniqueInput[] packageHotelsId
    );

    /// <summary>
    /// Connect multiple SightSeeingsItems records to Packages
    /// </summary>
    public Task ConnectSightSeeingsItems(
        PackagesWhereUniqueInput uniqueId,
        SightSeeingsWhereUniqueInput[] sightSeeingsId
    );

    /// <summary>
    /// Disconnect multiple SightSeeingsItems records from Packages
    /// </summary>
    public Task DisconnectSightSeeingsItems(
        PackagesWhereUniqueInput uniqueId,
        SightSeeingsWhereUniqueInput[] sightSeeingsId
    );

    /// <summary>
    /// Find multiple SightSeeingsItems records for Packages
    /// </summary>
    public Task<List<SightSeeings>> FindSightSeeingsItems(
        PackagesWhereUniqueInput uniqueId,
        SightSeeingsFindManyArgs SightSeeingsFindManyArgs
    );

    /// <summary>
    /// Update multiple SightSeeingsItems records for Packages
    /// </summary>
    public Task UpdateSightSeeingsItems(
        PackagesWhereUniqueInput uniqueId,
        SightSeeingsWhereUniqueInput[] sightSeeingsId
    );
}
