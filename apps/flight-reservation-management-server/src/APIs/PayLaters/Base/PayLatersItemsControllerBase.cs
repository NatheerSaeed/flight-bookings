using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PayLatersControllerBase : ControllerBase
{
    protected readonly IPayLatersService _service;

    public PayLatersControllerBase(IPayLatersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PayLaters
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PayLaters>> CreatePayLater(PayLaterCreateInput input)
    {
        var payLaters = await _service.CreatePayLater(input);

        return CreatedAtAction(nameof(PayLaters), new { id = payLaters.Id }, payLaters);
    }

    /// <summary>
    /// Delete one PayLaters
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePayLater([FromRoute()] PayLatersWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeletePayLater(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many PayLatersItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<PayLaters>>> PayLatersItems(
        [FromQuery()] PayLaterFindManyArgs filter
    )
    {
        return Ok(await _service.PayLatersItems(filter));
    }

    /// <summary>
    /// Meta data about PayLaters records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PayLatersItemsMeta(
        [FromQuery()] PayLaterFindManyArgs filter
    )
    {
        return Ok(await _service.PayLatersItemsMeta(filter));
    }

    /// <summary>
    /// Get one PayLaters
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<PayLaters>> PayLaters(
        [FromRoute()] PayLatersWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.PayLaters(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one PayLaters
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePayLater(
        [FromRoute()] PayLatersWhereUniqueInput uniqueId,
        [FromQuery()] PayLaterUpdateInput payLatersUpdateDto
    )
    {
        try
        {
            await _service.UpdatePayLater(uniqueId, payLatersUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a user_ record for PayLaters
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] PayLatersWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}
