using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPackagesService
{
    /// <summary>
    /// Create one Packages
    /// </summary>
    public Task<Packages> CreatePackage(PackageCreateInput packages);

    /// <summary>
    /// Delete one Packages
    /// </summary>
    public Task DeletePackage(PackagesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PackagesItems
    /// </summary>
    public Task<List<Packages>> PackagesSearchAsync(PackageFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Packages records
    /// </summary>
    public Task<MetadataDto> PackagesItemsMeta(PackageFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Packages
    /// </summary>
    public Task<Packages> Packages(PackagesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Packages
    /// </summary>
    public Task UpdatePackage(PackagesWhereUniqueInput uniqueId, PackageUpdateInput updateDto);

    /// <summary>
    /// Connect multiple AttractionsItems records to Packages
    /// </summary>
    public Task ConnectAttractionsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        AttractionsWhereUniqueInput[] attractionsId
    );

    /// <summary>
    /// Disconnect multiple AttractionsItems records from Packages
    /// </summary>
    public Task DisconnectAttractionsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        AttractionsWhereUniqueInput[] attractionsId
    );

    /// <summary>
    /// Find multiple AttractionsItems records for Packages
    /// </summary>
    public Task<List<Attractions>> FindAttractionsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        AttractionFindManyArgs AttractionFindManyArgs
    );

    /// <summary>
    /// Update multiple AttractionsItems records for Packages
    /// </summary>
    public Task UpdateAttractionsItem(
        PackagesWhereUniqueInput uniqueId,
        AttractionsWhereUniqueInput[] attractionsId
    );

    /// <summary>
    /// Connect multiple FlightDealsItems records to Packages
    /// </summary>
    public Task ConnectFlightDealsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        FlightDealsWhereUniqueInput[] flightDealsId
    );

    /// <summary>
    /// Disconnect multiple FlightDealsItems records from Packages
    /// </summary>
    public Task DisconnectFlightDealsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        FlightDealsWhereUniqueInput[] flightDealsId
    );

    /// <summary>
    /// Find multiple FlightDealsItems records for Packages
    /// </summary>
    public Task<List<FlightDeals>> FindFlightDealsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        FlightDealFindManyArgs FlightDealFindManyArgs
    );

    /// <summary>
    /// Update multiple FlightDealsItems records for Packages
    /// </summary>
    public Task UpdateFlightDealsItem(
        PackagesWhereUniqueInput uniqueId,
        FlightDealsWhereUniqueInput[] flightDealsId
    );

    /// <summary>
    /// Connect multiple GalleriesItems records to Packages
    /// </summary>
    public Task ConnectGalleriesSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        GalleriesWhereUniqueInput[] galleriesId
    );

    /// <summary>
    /// Disconnect multiple GalleriesItems records from Packages
    /// </summary>
    public Task DisconnectGalleriesSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        GalleriesWhereUniqueInput[] galleriesId
    );

    /// <summary>
    /// Find multiple GalleriesItems records for Packages
    /// </summary>
    public Task<List<Galleries>> FindGalleriesSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        GallerieFindManyArgs GallerieFindManyArgs
    );

    /// <summary>
    /// Update multiple GalleriesItems records for Packages
    /// </summary>
    public Task UpdateGalleriesItem(
        PackagesWhereUniqueInput uniqueId,
        GalleriesWhereUniqueInput[] galleriesId
    );

    /// <summary>
    /// Connect multiple GoodToKnowsItems records to Packages
    /// </summary>
    public Task ConnectGoodToKnowsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        GoodToKnowsWhereUniqueInput[] goodToKnowsId
    );

    /// <summary>
    /// Disconnect multiple GoodToKnowsItems records from Packages
    /// </summary>
    public Task DisconnectGoodToKnowsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        GoodToKnowsWhereUniqueInput[] goodToKnowsId
    );

    /// <summary>
    /// Find multiple GoodToKnowsItems records for Packages
    /// </summary>
    public Task<List<GoodToKnows>> FindGoodToKnowsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        GoodToKnowFindManyArgs GoodToKnowFindManyArgs
    );

    /// <summary>
    /// Update multiple GoodToKnowsItems records for Packages
    /// </summary>
    public Task UpdateGoodToKnowsItem(
        PackagesWhereUniqueInput uniqueId,
        GoodToKnowsWhereUniqueInput[] goodToKnowsId
    );

    /// <summary>
    /// Connect multiple HotelDealsItems records to Packages
    /// </summary>
    public Task ConnectHotelDealsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        HotelDealsWhereUniqueInput[] hotelDealsId
    );

    /// <summary>
    /// Disconnect multiple HotelDealsItems records from Packages
    /// </summary>
    public Task DisconnectHotelDealsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        HotelDealsWhereUniqueInput[] hotelDealsId
    );

    /// <summary>
    /// Find multiple HotelDealsItems records for Packages
    /// </summary>
    public Task<List<HotelDeals>> FindHotelDealsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        HotelDealFindManyArgs HotelDealFindManyArgs
    );

    /// <summary>
    /// Update multiple HotelDealsItems records for Packages
    /// </summary>
    public Task UpdateHotelDealsItem(
        PackagesWhereUniqueInput uniqueId,
        HotelDealsWhereUniqueInput[] hotelDealsId
    );

    /// <summary>
    /// Connect multiple PackageAttractionsItems records to Packages
    /// </summary>
    public Task ConnectPackageAttractionsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageAttractionsWhereUniqueInput[] packageAttractionsId
    );

    /// <summary>
    /// Disconnect multiple PackageAttractionsItems records from Packages
    /// </summary>
    public Task DisconnectPackageAttractionsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageAttractionsWhereUniqueInput[] packageAttractionsId
    );

    /// <summary>
    /// Find multiple PackageAttractionsItems records for Packages
    /// </summary>
    public Task<List<PackageAttractions>> FindPackageAttractionsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageAttractionFindManyArgs PackageAttractionFindManyArgs
    );

    /// <summary>
    /// Update multiple PackageAttractionsItems records for Packages
    /// </summary>
    public Task UpdatePackageAttractionsItem(
        PackagesWhereUniqueInput uniqueId,
        PackageAttractionsWhereUniqueInput[] packageAttractionsId
    );

    /// <summary>
    /// Connect multiple PackageBookingsItems records to Packages
    /// </summary>
    public Task ConnectPackageBookingsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageBookingsWhereUniqueInput[] packageBookingsId
    );

    /// <summary>
    /// Disconnect multiple PackageBookingsItems records from Packages
    /// </summary>
    public Task DisconnectPackageBookingsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageBookingsWhereUniqueInput[] packageBookingsId
    );

    /// <summary>
    /// Find multiple PackageBookingsItems records for Packages
    /// </summary>
    public Task<List<PackageBookings>> FindPackageBookingsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageBookingFindManyArgs PackageBookingFindManyArgs
    );

    /// <summary>
    /// Update multiple PackageBookingsItems records for Packages
    /// </summary>
    public Task UpdatePackageBookingsItem(
        PackagesWhereUniqueInput uniqueId,
        PackageBookingsWhereUniqueInput[] packageBookingsId
    );

    /// <summary>
    /// Connect multiple PackageFlightsItems records to Packages
    /// </summary>
    public Task ConnectPackageFlightsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageFlightsWhereUniqueInput[] packageFlightsId
    );

    /// <summary>
    /// Disconnect multiple PackageFlightsItems records from Packages
    /// </summary>
    public Task DisconnectPackageFlightsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageFlightsWhereUniqueInput[] packageFlightsId
    );

    /// <summary>
    /// Find multiple PackageFlightsItems records for Packages
    /// </summary>
    public Task<List<PackageFlights>> FindPackageFlightsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageFlightFindManyArgs PackageFlightFindManyArgs
    );

    /// <summary>
    /// Update multiple PackageFlightsItems records for Packages
    /// </summary>
    public Task UpdatePackageFlightsItem(
        PackagesWhereUniqueInput uniqueId,
        PackageFlightsWhereUniqueInput[] packageFlightsId
    );

    /// <summary>
    /// Connect multiple PackageHotelsItems records to Packages
    /// </summary>
    public Task ConnectPackageHotelsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageHotelsWhereUniqueInput[] packageHotelsId
    );

    /// <summary>
    /// Disconnect multiple PackageHotelsItems records from Packages
    /// </summary>
    public Task DisconnectPackageHotelsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageHotelsWhereUniqueInput[] packageHotelsId
    );

    /// <summary>
    /// Find multiple PackageHotelsItems records for Packages
    /// </summary>
    public Task<List<PackageHotels>> FindPackageHotelsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        PackageHotelFindManyArgs PackageHotelFindManyArgs
    );

    /// <summary>
    /// Update multiple PackageHotelsItems records for Packages
    /// </summary>
    public Task UpdatePackageHotelsItem(
        PackagesWhereUniqueInput uniqueId,
        PackageHotelsWhereUniqueInput[] packageHotelsId
    );

    /// <summary>
    /// Connect multiple SightSeeingsItems records to Packages
    /// </summary>
    public Task ConnectSightSeeingsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        SightSeeingsWhereUniqueInput[] sightSeeingsId
    );

    /// <summary>
    /// Disconnect multiple SightSeeingsItems records from Packages
    /// </summary>
    public Task DisconnectSightSeeingsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        SightSeeingsWhereUniqueInput[] sightSeeingsId
    );

    /// <summary>
    /// Find multiple SightSeeingsItems records for Packages
    /// </summary>
    public Task<List<SightSeeings>> FindSightSeeingsSearchAsync(
        PackagesWhereUniqueInput uniqueId,
        SightSeeingFindManyArgs SightSeeingFindManyArgs
    );

    /// <summary>
    /// Update multiple SightSeeingsItems records for Packages
    /// </summary>
    public Task UpdateSightSeeingsItem(
        PackagesWhereUniqueInput uniqueId,
        SightSeeingsWhereUniqueInput[] sightSeeingsId
    );
}
