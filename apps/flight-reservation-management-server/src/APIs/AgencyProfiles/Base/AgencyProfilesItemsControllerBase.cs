using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AgencyProfilesControllerBase : ControllerBase
{
    protected readonly IAgencyProfilesService _service;

    public AgencyProfilesControllerBase(IAgencyProfilesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one AgencyProfiles
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<AgencyProfiles>> CreateAgencyProfiles(
        AgencyProfileCreateInput input
    )
    {
        var agencyProfiles = await _service.CreateAgencyProfiles(input);

        return CreatedAtAction(
            nameof(AgencyProfiles),
            new { id = agencyProfiles.Id },
            agencyProfiles
        );
    }

    /// <summary>
    /// Delete one AgencyProfiles
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAgencyProfiles(
        [FromRoute()] AgencyProfilesWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteAgencyProfiles(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many AgencyProfilesItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<AgencyProfiles>>> AgencyProfilesItems(
        [FromQuery()] AgencyProfileFindManyArgs filter
    )
    {
        return Ok(await _service.AgencyProfilesItems(filter));
    }

    /// <summary>
    /// Meta data about AgencyProfiles records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AgencyProfilesItemsMeta(
        [FromQuery()] AgencyProfileFindManyArgs filter
    )
    {
        return Ok(await _service.AgencyProfilesItemsMeta(filter));
    }

    /// <summary>
    /// Get one AgencyProfiles
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<AgencyProfiles>> AgencyProfiles(
        [FromRoute()] AgencyProfilesWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.AgencyProfiles(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one AgencyProfiles
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAgencyProfiles(
        [FromRoute()] AgencyProfilesWhereUniqueInput uniqueId,
        [FromQuery()] AgencyProfileUpdateInput agencyProfilesUpdateDto
    )
    {
        try
        {
            await _service.UpdateAgencyProfiles(uniqueId, agencyProfilesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a user_ record for AgencyProfiles
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] AgencyProfilesWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}
