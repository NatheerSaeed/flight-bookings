using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IMarkupsService
{
    /// <summary>
    /// Create one Markups
    /// </summary>
    public Task<Markups> CreateMarkup(MarkupCreateInput markups);

    /// <summary>
    /// Delete one Markups
    /// </summary>
    public Task DeleteMarkup(MarkupsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many MarkupsItems
    /// </summary>
    public Task<List<Markups>> MarkupsItems(MarkupFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Markups records
    /// </summary>
    public Task<MetadataDto> MarkupsItemsMeta(MarkupFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Markups
    /// </summary>
    public Task<Markups> Markups(MarkupsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Markups
    /// </summary>
    public Task UpdateMarkup(MarkupsWhereUniqueInput uniqueId, MarkupUpdateInput updateDto);

    /// <summary>
    /// Get a role_ record for Markups
    /// </summary>
    public Task<Roles> GetRole(MarkupsWhereUniqueInput uniqueId);
}
