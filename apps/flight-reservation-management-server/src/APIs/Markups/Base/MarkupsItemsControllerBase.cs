using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MarkupsControllerBase : ControllerBase
{
    protected readonly IMarkupsService _service;

    public MarkupsControllerBase(IMarkupsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Markups
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Markups>> CreateMarkup(MarkupCreateInput input)
    {
        var markups = await _service.CreateMarkup(input);

        return CreatedAtAction(nameof(Markups), new { id = markups.Id }, markups);
    }

    /// <summary>
    /// Delete one Markups
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteMarkup([FromRoute()] MarkupsWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteMarkup(uniqueId);
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
        [FromQuery()] MarkupFindManyArgs filter
    )
    {
        return Ok(await _service.MarkupsItems(filter));
    }

    /// <summary>
    /// Meta data about Markups records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> MarkupsItemsMeta(
        [FromQuery()] MarkupFindManyArgs filter
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
    public async Task<ActionResult> UpdateMarkup(
        [FromRoute()] MarkupsWhereUniqueInput uniqueId,
        [FromQuery()] MarkupUpdateInput markupsUpdateDto
    )
    {
        try
        {
            await _service.UpdateMarkup(uniqueId, markupsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a role_ record for Markups
    /// </summary>
    [HttpGet("{Id}/role")]
    public async Task<ActionResult<List<Roles>>> GetRole(
        [FromRoute()] MarkupsWhereUniqueInput uniqueId
    )
    {
        var roles = await _service.GetRole(uniqueId);
        return Ok(roles);
    }
}
