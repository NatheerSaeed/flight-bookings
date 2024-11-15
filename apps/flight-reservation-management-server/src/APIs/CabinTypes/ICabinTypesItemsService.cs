using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface ICabinTypesService
{
    /// <summary>
    /// Create one CabinTypes
    /// </summary>
    public Task<CabinTypes> CreateCabinType(CabinTypeCreateInput cabintypes);

    /// <summary>
    /// Delete one CabinTypes
    /// </summary>
    public Task DeleteCabinType(CabinTypesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many CabinTypesItems
    /// </summary>
    public Task<List<CabinTypes>> CabinTypesItems(CabinTypeFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about CabinTypes records
    /// </summary>
    public Task<MetadataDto> CabinTypesItemsMeta(CabinTypeFindManyArgs findManyArgs);

    /// <summary>
    /// Get one CabinTypes
    /// </summary>
    public Task<CabinTypes> CabinTypes(CabinTypesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one CabinTypes
    /// </summary>
    public Task UpdateCabinType(
        CabinTypesWhereUniqueInput uniqueId,
        CabinTypeUpdateInput updateDto
    );
}
