using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPackagesService
{
    /// <summary>
    /// Create one Packages
    /// </summary>
    public Task<Packages> CreatePackages(PackageCreateInput packages);

    /// <summary>
    /// Delete one Packages
    /// </summary>
    public Task DeletePackages(PackagesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PackagesItems
    /// </summary>
    public Task<List<Packages>> PackagesItems(PackageFindManyArgs findManyArgs);

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
    public Task UpdatePackages(PackagesWhereUniqueInput uniqueId, PackageUpdateInput updateDto);

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
        AttractionFindManyArgs AttractionFindManyArgs
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
        FlightDealFindManyArgs FlightDealFindManyArgs
    );

    /// <summary>
    /// Update multiple FlightDealsItems records for Packages
    /// </summary>
    public Task UpdateFlightDealsItems(
        PackagesWhereUniqueInput uniqueId,
        FlightDealsWhereUniqueInput[] flightDealsId
    );

    /// <summary>
    /// Connect multiple GalleriesItems records to Packages
    /// </summary>
    public Task ConnectGalleriesItems(
        PackagesWhereUniqueInput uniqueId,
        GalleriesWhereUniqueInput[] galleriesId
    );

    /// <summary>
    /// Disconnect multiple GalleriesItems records from Packages
    /// </summary>
    public Task DisconnectGalleriesItems(
        PackagesWhereUniqueInput uniqueId,
        GalleriesWhereUniqueInput[] galleriesId
    );

    /// <summary>
    /// Find multiple GalleriesItems records for Packages
    /// </summary>
    public Task<List<Galleries>> FindGalleriesItems(
        PackagesWhereUniqueInput uniqueId,
        GallerieFindManyArgs GallerieFindManyArgs
    );

    /// <summary>
    /// Update multiple GalleriesItems records for Packages
    /// </summary>
    public Task UpdateGalleriesItems(
        PackagesWhereUniqueInput uniqueId,
        GalleriesWhereUniqueInput[] galleriesId
    );

    /// <summary>
    /// Connect multiple GoodToKnowsItems records to Packages
    /// </summary>
    public Task ConnectGoodToKnowsItems(
        PackagesWhereUniqueInput uniqueId,
        GoodToKnowsWhereUniqueInput[] goodToKnowsId
    );

    /// <summary>
    /// Disconnect multiple GoodToKnowsItems records from Packages
    /// </summary>
    public Task DisconnectGoodToKnowsItems(
        PackagesWhereUniqueInput uniqueId,
        GoodToKnowsWhereUniqueInput[] goodToKnowsId
    );

    /// <summary>
    /// Find multiple GoodToKnowsItems records for Packages
    /// </summary>
    public Task<List<GoodToKnows>> FindGoodToKnowsItems(
        PackagesWhereUniqueInput uniqueId,
        GoodToKnowFindManyArgs GoodToKnowFindManyArgs
    );

    /// <summary>
    /// Update multiple GoodToKnowsItems records for Packages
    /// </summary>
    public Task UpdateGoodToKnowsItems(
        PackagesWhereUniqueInput uniqueId,
        GoodToKnowsWhereUniqueInput[] goodToKnowsId
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
        HotelDealFindManyArgs HotelDealFindManyArgs
    );

    /// <summary>
    /// Update multiple HotelDealsItems records for Packages
    /// </summary>
    public Task UpdateHotelDealsItems(
        PackagesWhereUniqueInput uniqueId,
        HotelDealsWhereUniqueInput[] hotelDealsId
    );

    /// <summary>
    /// Connect multiple PackageAttractionsItems records to Packages
    /// </summary>
    public Task ConnectPackageAttractionsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageAttractionsWhereUniqueInput[] packageAttractionsId
    );

    /// <summary>
    /// Disconnect multiple PackageAttractionsItems records from Packages
    /// </summary>
    public Task DisconnectPackageAttractionsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageAttractionsWhereUniqueInput[] packageAttractionsId
    );

    /// <summary>
    /// Find multiple PackageAttractionsItems records for Packages
    /// </summary>
    public Task<List<PackageAttractions>> FindPackageAttractionsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageAttractionFindManyArgs PackageAttractionFindManyArgs
    );

    /// <summary>
    /// Update multiple PackageAttractionsItems records for Packages
    /// </summary>
    public Task UpdatePackageAttractionsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageAttractionsWhereUniqueInput[] packageAttractionsId
    );

    /// <summary>
    /// Connect multiple PackageBookingsItems records to Packages
    /// </summary>
    public Task ConnectPackageBookingsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageBookingsWhereUniqueInput[] packageBookingsId
    );

    /// <summary>
    /// Disconnect multiple PackageBookingsItems records from Packages
    /// </summary>
    public Task DisconnectPackageBookingsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageBookingsWhereUniqueInput[] packageBookingsId
    );

    /// <summary>
    /// Find multiple PackageBookingsItems records for Packages
    /// </summary>
    public Task<List<PackageBookings>> FindPackageBookingsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageBookingFindManyArgs PackageBookingFindManyArgs
    );

    /// <summary>
    /// Update multiple PackageBookingsItems records for Packages
    /// </summary>
    public Task UpdatePackageBookingsItems(
        PackagesWhereUniqueInput uniqueId,
        PackageBookingsWhereUniqueInput[] packageBookingsId
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
        PackageFlightFindManyArgs PackageFlightFindManyArgs
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
        PackageHotelFindManyArgs PackageHotelFindManyArgs
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
        SightSeeingFindManyArgs SightSeeingFindManyArgs
    );

    /// <summary>
    /// Update multiple SightSeeingsItems records for Packages
    /// </summary>
    public Task UpdateSightSeeingsItems(
        PackagesWhereUniqueInput uniqueId,
        SightSeeingsWhereUniqueInput[] sightSeeingsId
    );
}
