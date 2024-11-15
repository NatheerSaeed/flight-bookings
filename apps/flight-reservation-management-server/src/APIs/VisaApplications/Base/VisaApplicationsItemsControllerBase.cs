using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class VisaApplicationsControllerBase : ControllerBase
{
    protected readonly IVisaApplicationsService _service;

    public VisaApplicationsControllerBase(IVisaApplicationsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one VisaApplications
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<VisaApplications>> CreateVisaApplication(
        VisaApplicationCreateInput input
    )
    {
        var visaApplications = await _service.CreateVisaApplication(input);

        return CreatedAtAction(
            nameof(VisaApplications),
            new { id = visaApplications.Id },
            visaApplications
        );
    }

    /// <summary>
    /// Delete one VisaApplications
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteVisaApplication(
        [FromRoute()] VisaApplicationsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteVisaApplication(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many VisaApplicationsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<VisaApplications>>> VisaApplicationsItems(
        [FromQuery()] VisaApplicationFindManyArgs filter
    )
    {
        return Ok(await _service.VisaApplicationsItems(filter));
    }

    /// <summary>
    /// Meta data about VisaApplications records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> VisaApplicationsItemsMeta(
        [FromQuery()] VisaApplicationFindManyArgs filter
    )
    {
        return Ok(await _service.VisaApplicationsItemsMeta(filter));
    }

    /// <summary>
    /// Get one VisaApplications
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<VisaApplications>> VisaApplications(
        [FromRoute()] VisaApplicationsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.VisaApplications(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one VisaApplications
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateVisaApplication(
        [FromRoute()] VisaApplicationsWhereUniqueInput uniqueId,
        [FromQuery()] VisaApplicationUpdateInput visaApplicationsUpdateDto
    )
    {
        try
        {
            await _service.UpdateVisaApplication(uniqueId, visaApplicationsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
