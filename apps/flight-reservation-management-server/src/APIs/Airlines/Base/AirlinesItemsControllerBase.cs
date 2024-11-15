using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AirlinesControllerBase : ControllerBase
{
    protected readonly IAirlinesService _service;

    public AirlinesControllerBase(IAirlinesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Airlines
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Airlines>> CreateAirline(AirlineCreateInput input)
    {
        var airlines = await _service.CreateAirline(input);

        return CreatedAtAction(nameof(Airlines), new { id = airlines.Id }, airlines);
    }

    /// <summary>
    /// Delete one Airlines
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAirline([FromRoute()] AirlinesWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteAirline(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many AirlinesItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Airlines>>> AirlinesSearchAsync(
        [FromQuery()] AirlineFindManyArgs filter
    )
    {
        return Ok(await _service.AirlinesSearchAsync(filter));
    }

    /// <summary>
    /// Meta data about Airlines records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AirlinesItemsMeta(
        [FromQuery()] AirlineFindManyArgs filter
    )
    {
        return Ok(await _service.AirlinesItemsMeta(filter));
    }

    /// <summary>
    /// Get one Airlines
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Airlines>> Airlines(
        [FromRoute()] AirlinesWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Airlines(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Airlines
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAirline(
        [FromRoute()] AirlinesWhereUniqueInput uniqueId,
        [FromQuery()] AirlineUpdateInput airlinesUpdateDto
    )
    {
        try
        {
            await _service.UpdateAirline(uniqueId, airlinesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a user_ record for Airlines
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] AirlinesWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}
