using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PasswordResetsItemsControllerBase : ControllerBase
{
    protected readonly IPasswordResetsItemsService _service;

    public PasswordResetsItemsControllerBase(IPasswordResetsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PasswordResets
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PasswordResets>> CreatePasswordResets(
        PasswordResetsCreateInput input
    )
    {
        var passwordResets = await _service.CreatePasswordResets(input);

        return CreatedAtAction(
            nameof(PasswordResets),
            new { id = passwordResets.Id },
            passwordResets
        );
    }

    /// <summary>
    /// Delete one PasswordResets
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePasswordResets(
        [FromRoute()] PasswordResetsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePasswordResets(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many PasswordResetsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<PasswordResets>>> PasswordResetsItems(
        [FromQuery()] PasswordResetsFindManyArgs filter
    )
    {
        return Ok(await _service.PasswordResetsItems(filter));
    }

    /// <summary>
    /// Meta data about PasswordResets records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PasswordResetsItemsMeta(
        [FromQuery()] PasswordResetsFindManyArgs filter
    )
    {
        return Ok(await _service.PasswordResetsItemsMeta(filter));
    }

    /// <summary>
    /// Get one PasswordResets
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<PasswordResets>> PasswordResets(
        [FromRoute()] PasswordResetsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.PasswordResets(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one PasswordResets
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePasswordResets(
        [FromRoute()] PasswordResetsWhereUniqueInput uniqueId,
        [FromQuery()] PasswordResetsUpdateInput passwordResetsUpdateDto
    )
    {
        try
        {
            await _service.UpdatePasswordResets(uniqueId, passwordResetsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
