using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PasswordResetsControllerBase : ControllerBase
{
    protected readonly IPasswordResetsService _service;

    public PasswordResetsControllerBase(IPasswordResetsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PasswordReset
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PasswordReset>> CreatePasswordReset(
        PasswordResetCreateInput input
    )
    {
        var passwordReset = await _service.CreatePasswordReset(input);

        return CreatedAtAction(nameof(PasswordReset), new { id = passwordReset.Id }, passwordReset);
    }

    /// <summary>
    /// Delete one PasswordReset
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePasswordReset(
        [FromRoute()] PasswordResetWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePasswordReset(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many PasswordResets
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<PasswordReset>>> PasswordResets(
        [FromQuery()] PasswordResetFindManyArgs filter
    )
    {
        return Ok(await _service.PasswordResets(filter));
    }

    /// <summary>
    /// Meta data about PasswordReset records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PasswordResetsMeta(
        [FromQuery()] PasswordResetFindManyArgs filter
    )
    {
        return Ok(await _service.PasswordResetsMeta(filter));
    }

    /// <summary>
    /// Get one PasswordReset
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<PasswordReset>> PasswordReset(
        [FromRoute()] PasswordResetWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.PasswordReset(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one PasswordReset
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePasswordReset(
        [FromRoute()] PasswordResetWhereUniqueInput uniqueId,
        [FromQuery()] PasswordResetUpdateInput passwordResetUpdateDto
    )
    {
        try
        {
            await _service.UpdatePasswordReset(uniqueId, passwordResetUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
