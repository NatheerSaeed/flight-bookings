using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class GendersControllerBase : ControllerBase
{
    protected readonly IGendersService _service;

    public GendersControllerBase(IGendersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Genders
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Genders>> CreateGender(GenderCreateInput input)
    {
        var genders = await _service.CreateGender(input);

        return CreatedAtAction(nameof(Genders), new { id = genders.Id }, genders);
    }

    /// <summary>
    /// Delete one Genders
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteGender([FromRoute()] GendersWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteGender(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many GendersItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Genders>>> GendersItems(
        [FromQuery()] GenderFindManyArgs filter
    )
    {
        return Ok(await _service.GendersItems(filter));
    }

    /// <summary>
    /// Meta data about Genders records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> GendersItemsMeta(
        [FromQuery()] GenderFindManyArgs filter
    )
    {
        return Ok(await _service.GendersItemsMeta(filter));
    }

    /// <summary>
    /// Get one Genders
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Genders>> Genders([FromRoute()] GendersWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Genders(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Genders
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateGender(
        [FromRoute()] GendersWhereUniqueInput uniqueId,
        [FromQuery()] GenderUpdateInput gendersUpdateDto
    )
    {
        try
        {
            await _service.UpdateGender(uniqueId, gendersUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple ProfilesItems records to Genders
    /// </summary>
    [HttpPost("{Id}/profilesItems")]
    public async Task<ActionResult> ConnectProfilesItems(
        [FromRoute()] GendersWhereUniqueInput uniqueId,
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
    /// Disconnect multiple ProfilesItems records from Genders
    /// </summary>
    [HttpDelete("{Id}/profilesItems")]
    public async Task<ActionResult> DisconnectProfilesItems(
        [FromRoute()] GendersWhereUniqueInput uniqueId,
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
    /// Find multiple ProfilesItems records for Genders
    /// </summary>
    [HttpGet("{Id}/profilesItems")]
    public async Task<ActionResult<List<Profiles>>> FindProfilesItems(
        [FromRoute()] GendersWhereUniqueInput uniqueId,
        [FromQuery()] ProfileFindManyArgs filter
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
    /// Update multiple ProfilesItems records for Genders
    /// </summary>
    [HttpPatch("{Id}/profilesItems")]
    public async Task<ActionResult> UpdateProfilesItem(
        [FromRoute()] GendersWhereUniqueInput uniqueId,
        [FromBody()] ProfilesWhereUniqueInput[] profilesItemsId
    )
    {
        try
        {
            await _service.UpdateProfilesItem(uniqueId, profilesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
