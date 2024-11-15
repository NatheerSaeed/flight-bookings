using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class RolesControllerBase : ControllerBase
{
    protected readonly IRolesService _service;

    public RolesControllerBase(IRolesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Roles
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Roles>> CreateRole(RoleCreateInput input)
    {
        var roles = await _service.CreateRole(input);

        return CreatedAtAction(nameof(Roles), new { id = roles.Id }, roles);
    }

    /// <summary>
    /// Delete one Roles
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteRole([FromRoute()] RolesWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteRole(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many RolesItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Roles>>> RolesSearchAsync(
        [FromQuery()] RoleFindManyArgs filter
    )
    {
        return Ok(await _service.RolesSearchAsync(filter));
    }

    /// <summary>
    /// Meta data about Roles records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> RolesItemsMeta(
        [FromQuery()] RoleFindManyArgs filter
    )
    {
        return Ok(await _service.RolesItemsMeta(filter));
    }

    /// <summary>
    /// Get one Roles
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Roles>> Roles([FromRoute()] RolesWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Roles(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Roles
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateRole(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromQuery()] RoleUpdateInput rolesUpdateDto
    )
    {
        try
        {
            await _service.UpdateRole(uniqueId, rolesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple HotelsItems records to Roles
    /// </summary>
    [HttpPost("{Id}/hotelsItems")]
    public async Task<ActionResult> ConnectHotelsSearchAsync(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromQuery()] HotelsWhereUniqueInput[] hotelsItemsId
    )
    {
        try
        {
            await _service.ConnectHotelsSearchAsync(uniqueId, hotelsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple HotelsItems records from Roles
    /// </summary>
    [HttpDelete("{Id}/hotelsItems")]
    public async Task<ActionResult> DisconnectHotelsSearchAsync(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromBody()] HotelsWhereUniqueInput[] hotelsItemsId
    )
    {
        try
        {
            await _service.DisconnectHotelsSearchAsync(uniqueId, hotelsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple HotelsItems records for Roles
    /// </summary>
    [HttpGet("{Id}/hotelsItems")]
    public async Task<ActionResult<List<Hotels>>> FindHotelsSearchAsync(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromQuery()] HotelFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindHotelsSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple HotelsItems records for Roles
    /// </summary>
    [HttpPatch("{Id}/hotelsItems")]
    public async Task<ActionResult> UpdateHotelsItem(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromBody()] HotelsWhereUniqueInput[] hotelsItemsId
    )
    {
        try
        {
            await _service.UpdateHotelsItem(uniqueId, hotelsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple MarkupsItems records to Roles
    /// </summary>
    [HttpPost("{Id}/markupsItems")]
    public async Task<ActionResult> ConnectMarkupsSearchAsync(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromQuery()] MarkupsWhereUniqueInput[] markupsItemsId
    )
    {
        try
        {
            await _service.ConnectMarkupsSearchAsync(uniqueId, markupsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple MarkupsItems records from Roles
    /// </summary>
    [HttpDelete("{Id}/markupsItems")]
    public async Task<ActionResult> DisconnectMarkupsSearchAsync(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromBody()] MarkupsWhereUniqueInput[] markupsItemsId
    )
    {
        try
        {
            await _service.DisconnectMarkupsSearchAsync(uniqueId, markupsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple MarkupsItems records for Roles
    /// </summary>
    [HttpGet("{Id}/markupsItems")]
    public async Task<ActionResult<List<Markups>>> FindMarkupsSearchAsync(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromQuery()] MarkupFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindMarkupsSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple MarkupsItems records for Roles
    /// </summary>
    [HttpPatch("{Id}/markupsItems")]
    public async Task<ActionResult> UpdateMarkupsItem(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromBody()] MarkupsWhereUniqueInput[] markupsItemsId
    )
    {
        try
        {
            await _service.UpdateMarkupsItem(uniqueId, markupsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a role_ record for Roles
    /// </summary>
    [HttpGet("{Id}/role")]
    public async Task<ActionResult<List<Roles>>> GetRole(
        [FromRoute()] RolesWhereUniqueInput uniqueId
    )
    {
        var roles = await _service.GetRole(uniqueId);
        return Ok(roles);
    }

    /// <summary>
    /// Connect multiple RolesItems records to Roles
    /// </summary>
    [HttpPost("{Id}/rolesItems")]
    public async Task<ActionResult> ConnectRolesSearchAsync(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromQuery()] RolesWhereUniqueInput[] rolesItemsId
    )
    {
        try
        {
            await _service.ConnectRolesSearchAsync(uniqueId, rolesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple RolesItems records from Roles
    /// </summary>
    [HttpDelete("{Id}/rolesItems")]
    public async Task<ActionResult> DisconnectRolesSearchAsync(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromBody()] RolesWhereUniqueInput[] rolesItemsId
    )
    {
        try
        {
            await _service.DisconnectRolesSearchAsync(uniqueId, rolesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple RolesItems records for Roles
    /// </summary>
    [HttpGet("{Id}/rolesItems")]
    public async Task<ActionResult<List<Roles>>> FindRolesSearchAsync(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromQuery()] RoleFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindRolesSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple RolesItems records for Roles
    /// </summary>
    [HttpPatch("{Id}/rolesItems")]
    public async Task<ActionResult> UpdateRolesItem(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromBody()] RolesWhereUniqueInput[] rolesItemsId
    )
    {
        try
        {
            await _service.UpdateRolesItem(uniqueId, rolesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
