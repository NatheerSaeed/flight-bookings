using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CommentsControllerBase : ControllerBase
{
    protected readonly ICommentsService _service;

    public CommentsControllerBase(ICommentsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Comments
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Comments>> CreateComments(CommentCreateInput input)
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
        [FromQuery()] CommentFindManyArgs filter
    )
    {
        return Ok(await _service.CommentsItems(filter));
    }

    /// <summary>
    /// Meta data about Comments records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CommentsItemsMeta(
        [FromQuery()] CommentFindManyArgs filter
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
        [FromQuery()] CommentUpdateInput commentsUpdateDto
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
