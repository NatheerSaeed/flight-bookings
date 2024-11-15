using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TitlesItemsControllerBase : ControllerBase
{
    protected readonly ITitlesItemsService _service;

    public TitlesItemsControllerBase(ITitlesItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Titles
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Titles>> CreateTitles(TitlesCreateInput input)
    {
        var titles = await _service.CreateTitles(input);

        return CreatedAtAction(nameof(Titles), new { id = titles.Id }, titles);
    }

    /// <summary>
    /// Delete one Titles
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteTitles([FromRoute()] TitlesWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteTitles(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many TitlesItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Titles>>> TitlesItems(
        [FromQuery()] TitlesFindManyArgs filter
    )
    {
        return Ok(await _service.TitlesItems(filter));
    }

    /// <summary>
    /// Meta data about Titles records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TitlesItemsMeta(
        [FromQuery()] TitlesFindManyArgs filter
    )
    {
        return Ok(await _service.TitlesItemsMeta(filter));
    }

    /// <summary>
    /// Get one Titles
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Titles>> Titles([FromRoute()] TitlesWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Titles(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Titles
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateTitles(
        [FromRoute()] TitlesWhereUniqueInput uniqueId,
        [FromQuery()] TitlesUpdateInput titlesUpdateDto
    )
    {
        try
        {
            await _service.UpdateTitles(uniqueId, titlesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple ProfilesItems records to Titles
    /// </summary>
    [HttpPost("{Id}/profilesItems")]
    public async Task<ActionResult> ConnectProfilesItems(
        [FromRoute()] TitlesWhereUniqueInput uniqueId,
        [FromQuery()] ProfilesWhereUniqueInput[] profilesItemsId
    )
    {
        try
        {
            await _service.ConnectProfilesItems(uniqueId, profilesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple ProfilesItems records from Titles
    /// </summary>
    [HttpDelete("{Id}/profilesItems")]
    public async Task<ActionResult> DisconnectProfilesItems(
        [FromRoute()] TitlesWhereUniqueInput uniqueId,
        [FromBody()] ProfilesWhereUniqueInput[] profilesItemsId
    )
    {
        try
        {
            await _service.DisconnectProfilesItems(uniqueId, profilesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple ProfilesItems records for Titles
    /// </summary>
    [HttpGet("{Id}/profilesItems")]
    public async Task<ActionResult<List<Profiles>>> FindProfilesItems(
        [FromRoute()] TitlesWhereUniqueInput uniqueId,
        [FromQuery()] ProfilesFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindProfilesItems(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple ProfilesItems records for Titles
    /// </summary>
    [HttpPatch("{Id}/profilesItems")]
    public async Task<ActionResult> UpdateProfilesItems(
        [FromRoute()] TitlesWhereUniqueInput uniqueId,
        [FromBody()] ProfilesWhereUniqueInput[] profilesItemsId
    )
    {
        try
        {
            await _service.UpdateProfilesItems(uniqueId, profilesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
