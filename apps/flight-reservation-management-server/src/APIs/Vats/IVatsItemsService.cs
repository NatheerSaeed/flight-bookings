using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IVatsService
{
    /// <summary>
    /// Create one Vats
    /// </summary>
    public Task<Vats> CreateVat(VatCreateInput vats);

    /// <summary>
    /// Delete one Vats
    /// </summary>
    public Task DeleteVat(VatsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many VatsItems
    /// </summary>
    public Task<List<Vats>> VatsSearchAsync(VatFindManyArgs findManyArgs);

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
    public Task UpdateVat(VatsWhereUniqueInput uniqueId, VatUpdateInput updateDto);
}
