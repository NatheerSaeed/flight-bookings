using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IMarkdownsService
{
    /// <summary>
    /// Create one Markdowns
    /// </summary>
    public Task<Markdowns> CreateMarkdowns(MarkdownCreateInput markdowns);

    /// <summary>
    /// Delete one Markdowns
    /// </summary>
    public Task DeleteMarkdowns(MarkdownsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many MarkdownsItems
    /// </summary>
    public Task<List<Markdowns>> MarkdownsItems(MarkdownFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Markdowns records
    /// </summary>
    public Task<MetadataDto> MarkdownsItemsMeta(MarkdownFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Markdowns
    /// </summary>
    public Task<Markdowns> Markdowns(MarkdownsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Markdowns
    /// </summary>
    public Task UpdateMarkdowns(MarkdownsWhereUniqueInput uniqueId, MarkdownUpdateInput updateDto);
}
