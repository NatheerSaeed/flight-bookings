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
    public async Task<ActionResult<Vats>> CreateVat(VatCreateInput input)
    {
        var vats = await _service.CreateVat(input);

        return CreatedAtAction(nameof(Vats), new { id = vats.Id }, vats);
    }

    /// <summary>
    /// Delete one Vats
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteVat([FromRoute()] VatsWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteVat(uniqueId);
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
    public async Task<ActionResult<List<Vats>>> VatsSearchAsync(
        [FromQuery()] VatFindManyArgs filter
    )
    {
        return Ok(await _service.VatsSearchAsync(filter));
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
    public async Task<ActionResult> UpdateVat(
        [FromRoute()] VatsWhereUniqueInput uniqueId,
        [FromQuery()] VatUpdateInput vatsUpdateDto
    )
    {
        try
        {
            await _service.UpdateVat(uniqueId, vatsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
