using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface ITravelPackagesService
{
    /// <summary>
    /// Create one TravelPackages
    /// </summary>
    public Task<TravelPackages> CreateTravelPackages(TravelPackageCreateInput travelpackages);

    /// <summary>
    /// Delete one TravelPackages
    /// </summary>
    public Task DeleteTravelPackages(TravelPackagesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many TravelPackagesItems
    /// </summary>
    public Task<List<TravelPackages>> TravelPackagesItems(TravelPackageFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about TravelPackages records
    /// </summary>
    public Task<MetadataDto> TravelPackagesItemsMeta(TravelPackageFindManyArgs findManyArgs);

    /// <summary>
    /// Get one TravelPackages
    /// </summary>
    public Task<TravelPackages> TravelPackages(TravelPackagesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one TravelPackages
    /// </summary>
    public Task UpdateTravelPackages(
        TravelPackagesWhereUniqueInput uniqueId,
        TravelPackageUpdateInput updateDto
    );
}
