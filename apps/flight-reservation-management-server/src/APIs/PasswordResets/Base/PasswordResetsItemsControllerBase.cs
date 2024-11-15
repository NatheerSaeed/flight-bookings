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
    /// Create one PasswordResets
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PasswordResets>> CreatePasswordReset(
        PasswordResetCreateInput input
    )
    {
        var passwordResets = await _service.CreatePasswordReset(input);

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
    public async Task<ActionResult> DeletePasswordReset(
        [FromRoute()] PasswordResetsWhereUniqueInput uniqueId
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
    /// Find many PasswordResetsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<PasswordResets>>> PasswordResetsSearchAsync(
        [FromQuery()] PasswordResetFindManyArgs filter
    )
    {
        return Ok(await _service.PasswordResetsSearchAsync(filter));
    }

    /// <summary>
    /// Meta data about PasswordResets records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PasswordResetsItemsMeta(
        [FromQuery()] PasswordResetFindManyArgs filter
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
    public async Task<ActionResult> UpdatePasswordReset(
        [FromRoute()] PasswordResetsWhereUniqueInput uniqueId,
        [FromQuery()] PasswordResetUpdateInput passwordResetsUpdateDto
    )
    {
        try
        {
            await _service.UpdatePasswordReset(uniqueId, passwordResetsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
