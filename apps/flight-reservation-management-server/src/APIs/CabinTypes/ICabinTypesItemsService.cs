using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface ICabinTypesItemsService
{
    /// <summary>
    /// Create one CabinTypes
    /// </summary>
    public Task<CabinTypes> CreateCabinTypes(CabinTypesCreateInput cabintypes);

    /// <summary>
    /// Delete one CabinTypes
    /// </summary>
    public Task DeleteCabinTypes(CabinTypesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many CabinTypesItems
    /// </summary>
    public Task<List<CabinTypes>> CabinTypesItems(CabinTypesFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about CabinTypes records
    /// </summary>
    public Task<MetadataDto> CabinTypesItemsMeta(CabinTypesFindManyArgs findManyArgs);

    /// <summary>
    /// Get one CabinTypes
    /// </summary>
    public Task<CabinTypes> CabinTypes(CabinTypesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one CabinTypes
    /// </summary>
    public Task UpdateCabinTypes(
        CabinTypesWhereUniqueInput uniqueId,
        CabinTypesUpdateInput updateDto
    );
}
