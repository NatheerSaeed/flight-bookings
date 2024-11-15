using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PayLatersItemsControllerBase : ControllerBase
{
    protected readonly IPayLatersItemsService _service;

    public PayLatersItemsControllerBase(IPayLatersItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PayLaters
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PayLaters>> CreatePayLaters(PayLatersCreateInput input)
    {
        var payLaters = await _service.CreatePayLaters(input);

        return CreatedAtAction(nameof(PayLaters), new { id = payLaters.Id }, payLaters);
    }

    /// <summary>
    /// Delete one PayLaters
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePayLaters(
        [FromRoute()] PayLatersWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePayLaters(uniqueId);
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
        [FromQuery()] PayLatersFindManyArgs filter
    )
    {
        return Ok(await _service.PayLatersItems(filter));
    }

    /// <summary>
    /// Meta data about PayLaters records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PayLatersItemsMeta(
        [FromQuery()] PayLatersFindManyArgs filter
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
    public async Task<ActionResult> UpdatePayLaters(
        [FromRoute()] PayLatersWhereUniqueInput uniqueId,
        [FromQuery()] PayLatersUpdateInput payLatersUpdateDto
    )
    {
        try
        {
            await _service.UpdatePayLaters(uniqueId, payLatersUpdateDto);
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
