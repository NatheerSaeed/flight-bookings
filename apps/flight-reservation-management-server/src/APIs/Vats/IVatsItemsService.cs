using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IVatsService
{
    /// <summary>
    /// Create one Vats
    /// </summary>
    public Task<Vats> CreateVats(VatCreateInput vats);

    /// <summary>
    /// Delete one Vats
    /// </summary>
    public Task DeleteVats(VatsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many VatsItems
    /// </summary>
    public Task<List<Vats>> VatsItems(VatFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Vats records
    /// </summary>
    public Task<MetadataDto> VatsItemsMeta(VatFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Vats
    /// </summary>
    public Task<Vats> Vats(VatsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Vats
    /// </summary>
    public Task UpdateVats(VatsWhereUniqueInput uniqueId, VatUpdateInput updateDto);
}
