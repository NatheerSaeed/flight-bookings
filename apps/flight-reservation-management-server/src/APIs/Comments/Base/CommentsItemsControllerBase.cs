using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CommentsItemsControllerBase : ControllerBase
{
    protected readonly ICommentsItemsService _service;

    public CommentsItemsControllerBase(ICommentsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Comments
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Comments>> CreateComments(CommentsCreateInput input)
    {
        var comments = await _service.CreateComments(input);

        return CreatedAtAction(nameof(Comments), new { id = comments.Id }, comments);
    }

    /// <summary>
    /// Delete one Comments
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteComments([FromRoute()] CommentsWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteComments(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many CommentsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Comments>>> CommentsItems(
        [FromQuery()] CommentsFindManyArgs filter
    )
    {
        return Ok(await _service.CommentsItems(filter));
    }

    /// <summary>
    /// Meta data about Comments records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CommentsItemsMeta(
        [FromQuery()] CommentsFindManyArgs filter
    )
    {
        return Ok(await _service.CommentsItemsMeta(filter));
    }

    /// <summary>
    /// Get one Comments
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Comments>> Comments(
        [FromRoute()] CommentsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Comments(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Comments
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateComments(
        [FromRoute()] CommentsWhereUniqueInput uniqueId,
        [FromQuery()] CommentsUpdateInput commentsUpdateDto
    )
    {
        try
        {
            await _service.UpdateComments(uniqueId, commentsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
