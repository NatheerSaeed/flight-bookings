using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class RolesItemsControllerBase : ControllerBase
{
    protected readonly IRolesItemsService _service;

    public RolesItemsControllerBase(IRolesItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Roles
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Roles>> CreateRoles(RolesCreateInput input)
    {
        var roles = await _service.CreateRoles(input);

        return CreatedAtAction(nameof(Roles), new { id = roles.Id }, roles);
    }

    /// <summary>
    /// Delete one Roles
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteRoles([FromRoute()] RolesWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteRoles(uniqueId);
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
    public async Task<ActionResult<List<Roles>>> RolesItems([FromQuery()] RolesFindManyArgs filter)
    {
        return Ok(await _service.RolesItems(filter));
    }

    /// <summary>
    /// Meta data about Roles records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> RolesItemsMeta(
        [FromQuery()] RolesFindManyArgs filter
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
    public async Task<ActionResult> UpdateRoles(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromQuery()] RolesUpdateInput rolesUpdateDto
    )
    {
        try
        {
            await _service.UpdateRoles(uniqueId, rolesUpdateDto);
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
    public async Task<ActionResult> ConnectHotelsItems(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromQuery()] HotelsWhereUniqueInput[] hotelsItemsId
    )
    {
        try
        {
            await _service.ConnectHotelsItems(uniqueId, hotelsItemsId);
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
    public async Task<ActionResult> DisconnectHotelsItems(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromBody()] HotelsWhereUniqueInput[] hotelsItemsId
    )
    {
        try
        {
            await _service.DisconnectHotelsItems(uniqueId, hotelsItemsId);
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
    public async Task<ActionResult<List<Hotels>>> FindHotelsItems(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromQuery()] HotelsFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindHotelsItems(uniqueId, filter));
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
    public async Task<ActionResult> UpdateHotelsItems(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromBody()] HotelsWhereUniqueInput[] hotelsItemsId
    )
    {
        try
        {
            await _service.UpdateHotelsItems(uniqueId, hotelsItemsId);
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
    public async Task<ActionResult> ConnectRolesItems(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromQuery()] RolesWhereUniqueInput[] rolesItemsId
    )
    {
        try
        {
            await _service.ConnectRolesItems(uniqueId, rolesItemsId);
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
    public async Task<ActionResult> DisconnectRolesItems(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromBody()] RolesWhereUniqueInput[] rolesItemsId
    )
    {
        try
        {
            await _service.DisconnectRolesItems(uniqueId, rolesItemsId);
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
    public async Task<ActionResult<List<Roles>>> FindRolesItems(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromQuery()] RolesFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindRolesItems(uniqueId, filter));
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
    public async Task<ActionResult> UpdateRolesItems(
        [FromRoute()] RolesWhereUniqueInput uniqueId,
        [FromBody()] RolesWhereUniqueInput[] rolesItemsId
    )
    {
        try
        {
            await _service.UpdateRolesItems(uniqueId, rolesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
