using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPackageFlightsItemsService
{
    /// <summary>
    /// Create one PackageFlights
    /// </summary>
    public Task<PackageFlights> CreatePackageFlights(PackageFlightsCreateInput packageflights);

    /// <summary>
    /// Delete one PackageFlights
    /// </summary>
    public Task DeletePackageFlights(PackageFlightsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PackageFlightsItems
    /// </summary>
    public Task<List<PackageFlights>> PackageFlightsItems(PackageFlightsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about PackageFlights records
    /// </summary>
    public Task<MetadataDto> PackageFlightsItemsMeta(PackageFlightsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PackageFlights
    /// </summary>
    public Task<PackageFlights> PackageFlights(PackageFlightsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PackageFlights
    /// </summary>
    public Task UpdatePackageFlights(
        PackageFlightsWhereUniqueInput uniqueId,
        PackageFlightsUpdateInput updateDto
    );

    /// <summary>
    /// Get a package_ record for PackageFlights
    /// </summary>
    public Task<Packages> GetPackageField(PackageFlightsWhereUniqueInput uniqueId);
}
