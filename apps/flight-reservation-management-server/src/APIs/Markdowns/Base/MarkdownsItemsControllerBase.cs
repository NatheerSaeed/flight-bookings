using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MarkdownsControllerBase : ControllerBase
{
    protected readonly IMarkdownsService _service;

    public MarkdownsControllerBase(IMarkdownsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Markdowns
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Markdowns>> CreateMarkdowns(MarkdownCreateInput input)
    {
        var markdowns = await _service.CreateMarkdowns(input);

        return CreatedAtAction(nameof(Markdowns), new { id = markdowns.Id }, markdowns);
    }

    /// <summary>
    /// Delete one Markdowns
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteMarkdowns(
        [FromRoute()] MarkdownsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteMarkdowns(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many MarkdownsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Markdowns>>> MarkdownsItems(
        [FromQuery()] MarkdownFindManyArgs filter
    )
    {
        return Ok(await _service.MarkdownsItems(filter));
    }

    /// <summary>
    /// Meta data about Markdowns records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> MarkdownsItemsMeta(
        [FromQuery()] MarkdownFindManyArgs filter
    )
    {
        return Ok(await _service.MarkdownsItemsMeta(filter));
    }

    /// <summary>
    /// Get one Markdowns
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Markdowns>> Markdowns(
        [FromRoute()] MarkdownsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Markdowns(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Markdowns
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateMarkdowns(
        [FromRoute()] MarkdownsWhereUniqueInput uniqueId,
        [FromQuery()] MarkdownUpdateInput markdownsUpdateDto
    )
    {
        try
        {
            await _service.UpdateMarkdowns(uniqueId, markdownsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
