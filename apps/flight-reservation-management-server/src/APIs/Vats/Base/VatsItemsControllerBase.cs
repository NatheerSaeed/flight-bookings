using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class VatsControllerBase : ControllerBase
{
    protected readonly IVatsService _service;

    public VatsControllerBase(IVatsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Vats
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Vats>> CreateVats(VatCreateInput input)
    {
        var vats = await _service.CreateVats(input);

        return CreatedAtAction(nameof(Vats), new { id = vats.Id }, vats);
    }

    /// <summary>
    /// Delete one Vats
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteVats([FromRoute()] VatsWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteVats(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many VatsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Vats>>> VatsItems([FromQuery()] VatFindManyArgs filter)
    {
        return Ok(await _service.VatsItems(filter));
    }

    /// <summary>
    /// Meta data about Vats records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> VatsItemsMeta([FromQuery()] VatFindManyArgs filter)
    {
        return Ok(await _service.VatsItemsMeta(filter));
    }

    /// <summary>
    /// Get one Vats
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Vats>> Vats([FromRoute()] VatsWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Vats(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Vats
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateVats(
        [FromRoute()] VatsWhereUniqueInput uniqueId,
        [FromQuery()] VatUpdateInput vatsUpdateDto
    )
    {
        try
        {
            await _service.UpdateVats(uniqueId, vatsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
