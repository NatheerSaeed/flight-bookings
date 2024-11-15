using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CooperateCustomerProfilesItemsControllerBase : ControllerBase
{
    protected readonly ICooperateCustomerProfilesItemsService _service;

    public CooperateCustomerProfilesItemsControllerBase(
        ICooperateCustomerProfilesItemsService service
    )
    {
        _service = service;
    }

    /// <summary>
    /// Create one CooperateCustomerProfiles
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<CooperateCustomerProfiles>> CreateCooperateCustomerProfiles(
        CooperateCustomerProfilesCreateInput input
    )
    {
        var cooperateCustomerProfiles = await _service.CreateCooperateCustomerProfiles(input);

        return CreatedAtAction(
            nameof(CooperateCustomerProfiles),
            new { id = cooperateCustomerProfiles.Id },
            cooperateCustomerProfiles
        );
    }

    /// <summary>
    /// Delete one CooperateCustomerProfiles
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCooperateCustomerProfiles(
        [FromRoute()] CooperateCustomerProfilesWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteCooperateCustomerProfiles(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many CooperateCustomerProfilesItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<CooperateCustomerProfiles>>> CooperateCustomerProfilesItems(
        [FromQuery()] CooperateCustomerProfilesFindManyArgs filter
    )
    {
        return Ok(await _service.CooperateCustomerProfilesItems(filter));
    }

    /// <summary>
    /// Meta data about CooperateCustomerProfiles records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CooperateCustomerProfilesItemsMeta(
        [FromQuery()] CooperateCustomerProfilesFindManyArgs filter
    )
    {
        return Ok(await _service.CooperateCustomerProfilesItemsMeta(filter));
    }

    /// <summary>
    /// Get one CooperateCustomerProfiles
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<CooperateCustomerProfiles>> CooperateCustomerProfiles(
        [FromRoute()] CooperateCustomerProfilesWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.CooperateCustomerProfiles(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one CooperateCustomerProfiles
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateCooperateCustomerProfiles(
        [FromRoute()] CooperateCustomerProfilesWhereUniqueInput uniqueId,
        [FromQuery()] CooperateCustomerProfilesUpdateInput cooperateCustomerProfilesUpdateDto
    )
    {
        try
        {
            await _service.UpdateCooperateCustomerProfiles(
                uniqueId,
                cooperateCustomerProfilesUpdateDto
            );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a user_ record for CooperateCustomerProfiles
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] CooperateCustomerProfilesWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}
