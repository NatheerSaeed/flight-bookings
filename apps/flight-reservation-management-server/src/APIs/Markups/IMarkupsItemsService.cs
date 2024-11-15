using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IMarkupsItemsService
{
    /// <summary>
    /// Create one Markups
    /// </summary>
    public Task<Markups> CreateMarkups(MarkupsCreateInput markups);

    /// <summary>
    /// Delete one Markups
    /// </summary>
    public Task DeleteMarkups(MarkupsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many MarkupsItems
    /// </summary>
    public Task<List<Markups>> MarkupsItems(MarkupsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Markups records
    /// </summary>
    public Task<MetadataDto> MarkupsItemsMeta(MarkupsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Markups
    /// </summary>
    public Task<Markups> Markups(MarkupsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Markups
    /// </summary>
    public Task UpdateMarkups(MarkupsWhereUniqueInput uniqueId, MarkupsUpdateInput updateDto);
}
