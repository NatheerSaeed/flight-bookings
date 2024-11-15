using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ProfilesControllerBase : ControllerBase
{
    protected readonly IProfilesService _service;

    public ProfilesControllerBase(IProfilesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Profiles
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Profiles>> CreateProfile(ProfileCreateInput input)
    {
        var profiles = await _service.CreateProfile(input);

        return CreatedAtAction(nameof(Profiles), new { id = profiles.Id }, profiles);
    }

    /// <summary>
    /// Delete one Profiles
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteProfile([FromRoute()] ProfilesWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteProfile(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ProfilesItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Profiles>>> ProfilesSearchAsync(
        [FromQuery()] ProfileFindManyArgs filter
    )
    {
        return Ok(await _service.ProfilesSearchAsync(filter));
    }

    /// <summary>
    /// Meta data about Profiles records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ProfilesItemsMeta(
        [FromQuery()] ProfileFindManyArgs filter
    )
    {
        return Ok(await _service.ProfilesItemsMeta(filter));
    }

    /// <summary>
    /// Get one Profiles
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Profiles>> Profiles(
        [FromRoute()] ProfilesWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Profiles(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Profiles
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateProfile(
        [FromRoute()] ProfilesWhereUniqueInput uniqueId,
        [FromQuery()] ProfileUpdateInput profilesUpdateDto
    )
    {
        try
        {
            await _service.UpdateProfile(uniqueId, profilesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a gender_ record for Profiles
    /// </summary>
    [HttpGet("{Id}/gender")]
    public async Task<ActionResult<List<Genders>>> GetGender(
        [FromRoute()] ProfilesWhereUniqueInput uniqueId
    )
    {
        var genders = await _service.GetGender(uniqueId);
        return Ok(genders);
    }

    /// <summary>
    /// Get a title_ record for Profiles
    /// </summary>
    [HttpGet("{Id}/title")]
    public async Task<ActionResult<List<Titles>>> GetTitle(
        [FromRoute()] ProfilesWhereUniqueInput uniqueId
    )
    {
        var titles = await _service.GetTitle(uniqueId);
        return Ok(titles);
    }

    /// <summary>
    /// Get a user_ record for Profiles
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] ProfilesWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}
