using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class BankPaymentsControllerBase : ControllerBase
{
    protected readonly IBankPaymentsService _service;

    public BankPaymentsControllerBase(IBankPaymentsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one BankPayments
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<BankPayments>> CreateBankPayment(BankPaymentCreateInput input)
    {
        var bankPayments = await _service.CreateBankPayment(input);

        return CreatedAtAction(nameof(BankPayments), new { id = bankPayments.Id }, bankPayments);
    }

    /// <summary>
    /// Delete one BankPayments
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteBankPayment(
        [FromRoute()] BankPaymentsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteBankPayment(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many BankPaymentsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<BankPayments>>> BankPaymentsSearchAsync(
        [FromQuery()] BankPaymentFindManyArgs filter
    )
    {
        return Ok(await _service.BankPaymentsSearchAsync(filter));
    }

    /// <summary>
    /// Meta data about BankPayments records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> BankPaymentsItemsMeta(
        [FromQuery()] BankPaymentFindManyArgs filter
    )
    {
        return Ok(await _service.BankPaymentsItemsMeta(filter));
    }

    /// <summary>
    /// Get one BankPayments
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<BankPayments>> BankPayments(
        [FromRoute()] BankPaymentsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.BankPayments(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one BankPayments
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateBankPayment(
        [FromRoute()] BankPaymentsWhereUniqueInput uniqueId,
        [FromQuery()] BankPaymentUpdateInput bankPaymentsUpdateDto
    )
    {
        try
        {
            await _service.UpdateBankPayment(uniqueId, bankPaymentsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a user_ record for BankPayments
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] BankPaymentsWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}
