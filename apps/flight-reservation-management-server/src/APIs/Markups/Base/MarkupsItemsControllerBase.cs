using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MarkupsItemsControllerBase : ControllerBase
{
    protected readonly IMarkupsItemsService _service;

    public MarkupsItemsControllerBase(IMarkupsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Markups
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Markups>> CreateMarkups(MarkupsCreateInput input)
    {
        var markups = await _service.CreateMarkups(input);

        return CreatedAtAction(nameof(Markups), new { id = markups.Id }, markups);
    }

    /// <summary>
    /// Delete one Markups
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteMarkups([FromRoute()] MarkupsWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteMarkups(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many MarkupsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Markups>>> MarkupsItems(
        [FromQuery()] MarkupsFindManyArgs filter
    )
    {
        return Ok(await _service.MarkupsItems(filter));
    }

    /// <summary>
    /// Meta data about Markups records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> MarkupsItemsMeta(
        [FromQuery()] MarkupsFindManyArgs filter
    )
    {
        return Ok(await _service.MarkupsItemsMeta(filter));
    }

    /// <summary>
    /// Get one Markups
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Markups>> Markups([FromRoute()] MarkupsWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Markups(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Markups
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateMarkups(
        [FromRoute()] MarkupsWhereUniqueInput uniqueId,
        [FromQuery()] MarkupsUpdateInput markupsUpdateDto
    )
    {
        try
        {
            await _service.UpdateMarkups(uniqueId, markupsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
